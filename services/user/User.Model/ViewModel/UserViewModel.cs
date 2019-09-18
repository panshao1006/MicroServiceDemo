using System;
using System.Collections.Generic;
using System.Text;
using User.Model.Model.User;

namespace User.Model.ViewModel
{
    public class UserViewModel
    {
        public string MItemID { set; get; }

        public string MName { set; get; }


        public UserViewModel ConvertViewModel(UserModel user)
        {
            if (user == null)
            {
                return null;
            }

            UserViewModel result = new UserViewModel()
            {
                MItemID = user.MItemID,
                MName = user.MFirstName + " " + user.MLastName
            };

            return result;
        }

    }
}
