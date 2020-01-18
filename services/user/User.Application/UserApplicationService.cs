using AutoMapper;
using Core.Common;
using Core.CustomException;
using Core.EventBus;
using Core.Http;
using System;
using System.Linq;
using User.Domain.AggregateUser.Entity;
using User.Domain.AggregateUser.Event;
using User.Domain.AggregateUser.Repository.PO;
using User.Domain.AggregateUser.Service;
using User.DTO;
using User.Infrastructure;
using User.Infrastructure.Data;

namespace User.Application
{
    public class UserApplicationService
    {
        protected UserDomainService _userDomainService;
        protected IMapper _mapper;
        protected IEventBus _eventBus;

        public UserApplicationService(UserDomainService userDomainService , IMapper mapper , IEventBus eventBus)
        {
            _userDomainService = userDomainService;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationResult Login(UserDTO userDTO)
        {
            OperationResult result = new OperationResult();

            if(!string.IsNullOrWhiteSpace(userDTO.EmailAddress) || !string.IsNullOrWhiteSpace(userDTO.Password))
            {
                result.Success = false;
                result.Messages.Add("请填写用户名和密码");
                result.Code = ((int)RequestFailCode.ParametersMissing).ToString();
            }

            var user = _userDomainService.GetUser(userDTO.EmailAddress , userDTO.Password);

            if (user == null)
            {
                result.Success = false;
                result.Messages.Add("用户名或密码不正确");
                result.Code = ((int)RequestFailCode.PasswordError).ToString();
                return result;
            }

            //如果存在的化，保存到Redis
            var tokenModel = new TokenDTO()
            {
                TokenId = GuidUtility.GetGuid(),
                UserId = user.Id,
                ExpiredDate = DateTime.Now.AddSeconds(3600),
                RefreshTokenId = GuidUtility.GetGuid()
            };

            RedisRepository.SaveUserToken(tokenModel);

            result.Success = true;
            result.Data = tokenModel;

            return result;
        }


        /// <summary>
        /// 创建超级管理员用户
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationResult CreateUser(UserDTO userDTO)
        {
            OperationResult result = new OperationResult();

            var user = _mapper.Map<User.Domain.AggregateUser.Entity.User>(userDTO);

            var emailTemplateUrl = ConfigurationManager.AppSetting("GatewayHost") + "/emailtemplates?type=1";
            EmailTemplateDTO emailTemplate = new EmailTemplateDTO();
            try
            {
                emailTemplate = new HttpClientUtility().Get<EmailTemplateDTO>(emailTemplateUrl);

                if(emailTemplate!=null && emailTemplate.Contents != null)
                {
                    var content = emailTemplate.Contents.FirstOrDefault(x => x.LangId == userDTO.LangId);

                    emailTemplate.Content = content != null ? content.Value : null;
                }
            }
            catch (Exception ex)
            {
                string message = "无法激活邮件模板：" + emailTemplateUrl + "错误详情：" + ex.Message;
                throw new RequestDataExcepiton(message);
            }

            if (emailTemplate == null || string.IsNullOrWhiteSpace(emailTemplate.Content))
            {
                result.Success = false;
                result.Messages.Add("无法找到激活邮件模板，无法完成注册");
                return result;
            }
            var emailTemplateDO = _mapper.Map<EmailTemplate>(emailTemplate);


            result = _userDomainService.CreateUser(user , emailTemplateDO);


            if (result.Success)
            {
                string activeUrl = ConfigurationManager.AppSetting("ActiveUrl") + "?id=" + user.UserActiveInfo.Id;
                string supportEamil = ConfigurationManager.AppSetting("FromEmail");

                _eventBus.PublishAsync<UserWaitActiveEvent>(new UserWaitActiveEvent()
                {
                    UserId = user.Id,
                    EmailAddress = user.EmailAddress,
                    EmailContent = string.Format(emailTemplate.Content , user.GetUserName() , activeUrl, supportEamil)
                });
            }

            return result;
        }


        /// <summary>
        /// 获取用户的激活信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActiveInfoDTO GetActiveInfo(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            var result = _userDomainService.GetUserActiveInfo(id);



            return result != null ? _mapper.Map<ActiveInfoDTO>(result) : null;
        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public OperationResult UpdateUser(UserDTO user)
        {
            OperationResult result = new OperationResult();

            var userDO = _mapper.Map<User.Domain.AggregateUser.Entity.User>(user);

            //激活
            if (!string.IsNullOrWhiteSpace(user.ActiveInfoId))
            {
                result = ActiveUser(user, userDO);
            }

            return result;
        }

        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="do"></param>
        /// <returns></returns>
        private OperationResult ActiveUser(UserDTO dto , User.Domain.AggregateUser.Entity.User @do)
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                result.Messages.Add("密码未必填项");
                return result;
            }

            if (dto.Password != dto.ConfimPassword)
            {
                result.Messages.Add("两次密码不一致");
                return result;
            }
            result = _userDomainService.ActiveUser(@do);

            return result;
        }


    }
}
