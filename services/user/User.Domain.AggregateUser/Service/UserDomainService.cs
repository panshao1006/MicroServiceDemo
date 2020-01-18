using AutoMapper;
using Core.Email;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using User.Domain.AggregateUser.Entity;
using User.Domain.AggregateUser.Repository.PO;
using User.Infrastructure;
using User.Infrastructure.Data;

namespace User.Domain.AggregateUser.Service
{
    public class UserDomainService
    {
        protected IRepository<UserPO> _repository;
        protected IRepository<UserActiveInfoPO> _activeInfoRepository;

        protected IMapper _mapper;

        public UserDomainService(IRepository<UserPO> repository, IRepository<UserActiveInfoPO> activeInfoRepository, IMapper mapper)
        {
            _repository = repository;
            _activeInfoRepository = activeInfoRepository;
            _mapper = mapper;
        }


        public User.Domain.AggregateUser.Entity.User GetUser(string email , string password)
        {
           var userPO = _repository.Query().AsNoTracking().FirstOrDefault(x => x.MEmailAddress == email && x.MPassword == password);

            if(userPO == null)
            {
                return null;
            }

            return _mapper.Map<User.Domain.AggregateUser.Entity.User>(userPO);

        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public OperationResult CreateUser(User.Domain.AggregateUser.Entity.User user , EmailTemplate emailTemplate)
        {
            OperationResult result = new OperationResult();

            if (user == null)
            {
                result.Messages.Add("用户信息未空");
                return result;
            }

            //基本数据校验
            result = user.Validate();
            if (!result.Success)
            {
                return result;
            }

            //检查邮箱是否已经注册过了
            var userInDB = GetUser(user.EmailAddress, user.Password);
            //如果已经激活过了，就不能进行注册
            if (userInDB != null && userInDB.Status == 1)
            {
                result.Success = false;
                result.Messages.Add("邮箱已经注册过了，不能再次进行注册");
                return result;
            }

            bool isUpdate = userInDB != null;

            User.Domain.AggregateUser.Entity.User finalUser = null;

            if (isUpdate)
            {
                finalUser = userInDB;
                finalUser.FirstName = user.FirstName;
                finalUser.LastName = user.LastName;
                finalUser.Phone = user.Phone;
                finalUser.Status = 0;
                finalUser.ModifyDate = DateTime.Now;
                finalUser.ModifierID = user.Id;

                //增加激活连接
                finalUser.CreateUserActiveEmail(1, emailTemplate);
            }
            else
            {
                finalUser = user;
                finalUser.CreateUser(1, emailTemplate);
            }


            var po = _mapper.Map<UserPO>(finalUser);

            if (isUpdate == true)
                _repository.UpdateEntity(po);
            else
                _repository.AddEntity(po);

            result.Success = _repository.SaveChanges() > 0;

            finalUser.UserActiveInfo.Id = po.UserActiveInfos.First().MItemID;
            user.UserActiveInfo = finalUser.UserActiveInfo;

            return result;
        }

        /// <summary>
        /// 发送激活邮件
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="subject"></param>
        /// <param name="emailContent"></param>
        /// <param name="toEmail"></param>
        /// <returns></returns>
        public OperationResult SendActiveEmail(string userId, string subject, string emailContent, string toEmail)
        {
            OperationResult result = new OperationResult();

            EmailClient client = new EmailClient();

            result.Success = client.Send(subject, toEmail, emailContent);

            return result;
          
        }

        /// <summary>
        /// 获取用户的激活信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserActiveInfo GetUserActiveInfo(string id)
        {
            var activeInfo = _activeInfoRepository.Query().AsNoTracking().FirstOrDefault(x => x.MItemID == id);

            if (activeInfo == null)
            {
                return null;
            }

            var result = _mapper.Map<UserActiveInfo>(activeInfo);

            //过期了也不返回
            if(result.ExpireDate< DateTime.Now)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// 用户激活
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public OperationResult ActiveUser(User.Domain.AggregateUser.Entity.User user)
        {
            var result = new OperationResult();

            var userPO = _repository.Query().First(x=>x.MItemID == user.Id);
            var activeInfo = _activeInfoRepository.Query().First(x => x.MItemID == user.ActiveInfoId);

            if(userPO == null)
            {
                result.Messages.Add("用户信息不存在");
                return result;
            }

            if (userPO.MIsTemp == 0)
            {
                result.Messages.Add("用户已经激活");
                return result;
            }

            if (activeInfo == null)
            {
                result.Messages.Add("用户激活信息不存在");
                return result;
            }

            userPO.MIsTemp = 0;
            userPO.MPassword = user.Password;
            userPO.MModifyDate = DateTime.Now;
            activeInfo.MIsDelete = true;
            activeInfo.MModifyDate = DateTime.Now;

            userPO.UserActiveInfos = new List<UserActiveInfoPO>() { activeInfo };

            _repository.UpdateEntity(userPO);

            result.Success = _repository.SaveChanges() > 0;


            return result;
        }
        
    }
}
