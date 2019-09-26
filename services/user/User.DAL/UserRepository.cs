using Core.ORM;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.DAL;
using User.Model;
using User.Model.Model.User;

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
        public UserModel GetUser(string eamil , string password)
        {
            var result = _orm.GetSqlClient<SqlSugarClient>().GetSimpleClient<UserModel>().GetSingle(x => x.MEmail == eamil && x.MPassword == password);

            return result;
        }

        public UserModel GetUser(string id)
        {
            var result = _orm.GetSqlClient<SqlSugarClient>().GetSimpleClient<UserModel>().GetById(id);

            return result;
        }

        /// <summary>
        /// 插入一个用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int InsertUser(UserModel user)
        {
            CommandInfo cmd = new CommandInfo();

            cmd.CommandText = string.Format("insert into t_sec_user(MItemID , MFirstName , MLastName ,MEmailAddress, MPassword) values('{0}','{1}','{2}','{3}','{4}')",
                user.MItemID, user.MFirstName, user.MLastName, user.MEmail, user.MPassword);

            var result = _orm.Execute(cmd);

            return result;
        }


         
    }
}
