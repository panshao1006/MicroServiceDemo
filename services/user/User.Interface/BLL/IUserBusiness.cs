using User.Model;
using User.Model.DTO;
using User.Model.DTO.User;

namespace User.Interface.BLL
{
    public interface IUserBusiness
    {
        UserDTO GetUser(string email, string password);

        OperationResult InsertUser(UserDTO user);

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        OperationResult Login(string email, string password);

        /// <summary>
        /// 校验token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        OperationResult ValidateToken(string token);


        MenuDTO GetUserMenu(string userId, string orgId);

        /// <summary>
        /// 获取一个token
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDTO GetUserByToken(string token);
    }
}
