using Core.Common.Field;
using Core.Common.FieldValidate;
using System;
using System.Collections.Generic;
using System.Text;
using User.Model.DAO.User;

namespace User.Model.DTO.User
{
    public class UserDTO : BaseDTO
    {
        public string Name
        {
            get { return FirstName + " " + LastName; }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        [FieldValidate(Require =true , FieldType = FieldType.Email)]
        public string Email { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        [FieldValidate(Require = true)]
        public string Password { set; get; }

        [FieldValidate(Require = true)]
        public string FirstName { set; get; }

        [FieldValidate(Require = true)]
        public string LastName { set; get; }

        /// <summary>
        /// 转换为DAO
        /// </summary>
        /// <returns></returns>
        public UserDAO Convert()
        {
            UserDAO dao = new UserDAO()
            {
                MItemID = Id,
                MPassword = Password,
                MFirstName = FirstName,
                MLastName = LastName
            };


            return dao;
        }

        /// <summary>
        /// 转换为DTO
        /// </summary>
        /// <param name="user"></param>
        public UserDTO Convert(UserDAO user)
        {
            UserDTO dto = null;

            if (user == null)
            {
                return dto;
            }
            dto = new UserDTO();
            dto.Id = user.MItemID;
            dto.FirstName = user.MFirstName;
            dto.LastName = user.MLastName;
            dto.IsActive = user.MIsActive;

            return dto;
        }
    }
}
