using Core.Cache;
using Core.Common;
using Core.Common.FieldValidate;
using Core.EventBus.Model.Email;
using System;
using System.Collections.Generic;
using User.Interface.BLL;
using User.Interface.DAL;
using User.Model;
using User.Model.DAO.User;
using User.Model.DTO;
using User.Model.DTO.User;
using User.Model.Filter;
using User.Model.ViewModel;

namespace User.BLL.User
{
    public class UserBusiness: IUserBusiness
    {
        private IUserRepository _userRepository;

        /// <summary>
        /// 缓存
        /// </summary>
        private ICache _cache;


        public UserBusiness(IUserRepository userRepository , ICache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }

        /// <summary>
        /// 新增账号
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public OperationResult InsertUser(UserDTO user)
        {
            OperationResult result = new OperationResult();

            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            result = Validate<UserDTO>(user);

            if (!result.Success)
            {
                return result;
            }

            user.Id = GuidUtility.GetGuid();
            
            int effRow = _userRepository.InsertUser(user.Convert());

            result.Success = effRow > 0;

            if (result.Success)
            {
                SendActivateMail(user);
            }


            result.Id = result.Success ? user.Id : null;

            return result;
        }

        /// <summary>
        /// 用户数据校验
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <param name="isUpdate"></param>
        /// <returns></returns>
        private OperationResult Validate<T>(T user, bool isUpdate = false) where T : class
        {
            OperationResult result = new OperationResult(true);
            List<string> tempValidateMessages;

            //基本字段的校验
            var validateResult = isUpdate ? user.ValidateNonNull<T>(out tempValidateMessages) : user.Validate<T>(out tempValidateMessages);

            if (!validateResult)
            {
                result.Success = false;

                result.Messages.AddRange(tempValidateMessages);
            }

            //一些其他业务逻辑的校验
            var emailValidateResult = ValidateEmail((user as UserDTO).Email);

            if (!emailValidateResult.Success)
            {
                result.Success = false;
                result.Messages.AddRange(emailValidateResult.Messages);
            }

            return result;
        }

        /// <summary>
        /// 邮箱是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public OperationResult ValidateEmail(string email)
        {
            OperationResult result = new OperationResult(true);

            //邮箱为空，不进行校验
            if (string.IsNullOrWhiteSpace(email))
            {
                return result;
            }

            UserFilter filter = new UserFilter() { Email = email};

            var user = _userRepository.GetUser(filter);

            if (user != null)
            {
                result.Success = false;
                result.Messages.Add($"邮箱{email}已注册");
            }

            return result;
        }


        /// <summary>
        /// 根据用户名和密码获取用户
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDTO GetUser(string email , string password)
        {
            UserFilter filter = new UserFilter() { Email = email , Password = password};

            UserDAO dao = _userRepository.GetUser(filter);

            UserDTO user = new UserDTO();
            user.Convert(dao);

            return user;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDTO GetUser(string id)
        {
            UserFilter filter = new UserFilter() { Id = id };

            UserDAO result = _userRepository.GetUser(filter);

            UserDTO user = new UserDTO();
            user.Convert(result);

            return user;
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public OperationResult Login(string email, string password)
        {
            OperationResult result = new OperationResult();

            var userModel = GetUser(email, password);

            if (userModel == null)
            {
                return result;
            }

            TokenDTO tokenModel = new TokenDTO()
            {
                UserId = userModel.Id,
                UserName = userModel.Name,
                Token = Guid.NewGuid().ToString(),
                ExpireDateTime = DateTime.Now.AddHours(1)
            };

            CacheModel tokenCache = new CacheModel()
            {
                CacheType = CacheType.KeyValue,
                Key = tokenModel.Token,
                Data = tokenModel,
            };


            result.Success = _cache.Add(tokenCache);

            result.Data = result.Success ? tokenModel : null;

            return result;
        }

        /// <summary>
        /// 校验token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public OperationResult ValidateToken(string token)
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrEmpty(token))
            {
                return result;
            }

            CacheFilter filter = new CacheFilter() { Key = token };

            var tokenCache = _cache.Query<TokenDTO>(filter);

            //没有找到token或者token的过期日期小于当前日期加一个小时
            if (tokenCache == null || tokenCache.ExpireDateTime < DateTime.Now)
            {
                return result;
            }

            tokenCache.ExpireDateTime = DateTime.Now.AddHours(1);

            CacheModel model = new CacheModel()
            {
                Key = tokenCache.Token,
                Data = tokenCache
            };

            //更新一下token的过期时间
            _cache.Update(model);

            result.Success = true;

            result.Data = tokenCache;

            return result;
        }

        /// <summary>
        /// 获取用户的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public MenuDTO GetUserMenu(string userId, string orgId)
        {
            //判断用户是否存在

            //判断组织是否存在

            //根据用户和组织查找可以使用的模块

            MenuDTO menu = new MenuDTO();


            return menu;
        }

        /// <summary>
        /// 获取一个token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public UserDTO GetUserByToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            CacheFilter cacheFilter = new CacheFilter() { Key = token };

            var tokenResult = _cache.Query<TokenDTO>(cacheFilter);

            if (tokenResult == null)
            {
                return null;
            }

            string userId = tokenResult.UserId;

            UserFilter filter = new UserFilter() { Id = userId };

            var user = _userRepository.GetUser(filter);

            var result = new UserDTO();
            result.Convert(user);

            return result;
        }

        /// <summary>
        /// 发送激活邮件
        /// </summary>
        /// <param name="email"></param>
        private void SendActivateMail(UserDTO user)
        {
            //string template = $"";
            EmailNotificationEvent emailNotificationEvent = new EmailNotificationEvent()
            {
                Email = user.Email
            };
        }
    }
}
