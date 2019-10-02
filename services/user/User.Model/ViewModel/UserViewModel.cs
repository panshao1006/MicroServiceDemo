using System;
using System.Collections.Generic;
using System.Text;
using User.Model.DTO.User;

namespace User.Model.ViewModel
{
    public class UserViewModel
    {
        public string Id { set; get; }

        public string Name { set; get; }


        public UserViewModel Convert(UserDTO user)
        {
            if (user == null)
            {
                return null;
            }

            UserViewModel result = new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name
            };

            return result;
        }

    }
}
