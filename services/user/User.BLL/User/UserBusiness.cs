using Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.BLL;
using User.Interface.DAL;
using User.Model;
using User.Model.Model;
using User.Model.Model.User;
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
        public OperationResult InsertUser(UserModel user)
        {
            OperationResult result = new OperationResult();

            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrWhiteSpace(user.MFirstName) || string.IsNullOrWhiteSpace(user.MLastName))
            {
                result.Message = "姓和名是必填项";
                result.Success = false;

                return result;
            }

            user.MItemID = Guid.NewGuid().ToString();
            
            int effRow = _userRepository.InsertUser(user);

            result.Success = effRow > 0;

            result.Id = result.Success ? user.MItemID : null;

            return result;
        }


        /// <summary>
        /// 根据用户名和密码获取用户
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserModel GetUser(string email , string password)
        {
            UserModel result = _userRepository.GetUser(email, password);

            return result;
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

            TokenModel tokenModel = new TokenModel()
            {
                UserId = userModel.MItemID,
                UserName = userModel.MName,
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
        public OperationResult CheckToken(string token)
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrEmpty(token))
            {
                return result;
            }

            CacheFilter filter = new CacheFilter() { Key = token };

            var tokenCache = _cache.Query<TokenModel>(filter);

            //没有找到token或者token的过期日期小于当前日期加一个小时
            if (tokenCache == null || tokenCache.ExpireDateTime < DateTime.Now.AddHours(1))
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
    }
}
