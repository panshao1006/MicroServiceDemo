using Core.ORM;
using SqlSugar;
using User.Interface.DAL;
using User.Model.DAO.User;
using User.Model.Filter;

namespace User.DAL
{
    public class UserRepository : BaseRepository , IUserRepository
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="eamil"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDAO GetUser(string eamil , string password)
        {
            var result = _orm.GetSqlClient<SqlSugarClient>().GetSimpleClient<UserDAO>().GetSingle(x => x.MEmail == eamil && x.MPassword == password);

            return result;
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public UserDAO GetUser(UserFilter filter)
        {
            if(filter == null)
            {
                return null;
            }

            var queryable = _orm.GetSqlClient<SqlSugarClient>().Queryable<UserDAO>()
                .WhereIF(!string.IsNullOrWhiteSpace(filter.Id), x => x.MItemID == filter.Id)
                 .WhereIF(!string.IsNullOrWhiteSpace(filter.Email), x => x.MEmail == filter.Email)
                  .WhereIF(!string.IsNullOrWhiteSpace(filter.Password), x => x.MPassword == filter.Password)
                   .WhereIF(!string.IsNullOrWhiteSpace(filter.Id), x => x.MItemID == filter.Id);

            var result = queryable.First();
            
            return result;
        }


        public UserDAO GetUser(string id)
        {
            var result = _orm.GetSqlClient<SqlSugarClient>().GetSimpleClient<UserDAO>().GetById(id);

            return result;
        }

        /// <summary>
        /// 插入一个用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int InsertUser(UserDAO user)
        {
            var result = _orm.GetSqlClient<SqlSugarClient>().Insertable<UserDAO>(user).ExecuteCommand();

            return result;
        }


         
    }
}
