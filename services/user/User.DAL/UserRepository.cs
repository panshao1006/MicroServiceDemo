using Core.ORM;
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
            CommandInfo cmd = new CommandInfo();

            cmd.CommandText = string.Format("select * from t_sec_user where MEmailAddress='{0}' and MPassword='{1}' and MIsDelete=0", eamil, password);

            var result = _orm.GetDataModel<UserModel>(cmd);

            return result;
        }

        public UserModel GetUser(string id)
        {
            CommandInfo cmd = new CommandInfo();

            cmd.CommandText = string.Format("select * from t_sec_user where id='{0}' and MIsDelete=0", id);

            var result = _orm.GetDataModel<UserModel>(cmd);

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
