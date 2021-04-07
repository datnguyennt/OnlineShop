using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserLoginDAO
    {
        WebDbContext context;

        public UserLoginDAO()
        {
            context = new WebDbContext();
        }

        public int LoginUser(String UserName, String UserPassword)
        {
            var result = context.LoginUser.SingleOrDefault(x => x.UserName.Contains(UserName) && x.UserPassword.Contains(UserPassword));
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public string Insert(LoginUser loginUser)
        {
            context.LoginUser.Add(loginUser);
            context.SaveChanges();
            return loginUser.UserName;
        }

        public LoginUser Find(string user)
        {
            return context.LoginUser.Find(user);
        }

        public List<LoginUser> ListAll()
        {
            return context.LoginUser.ToList();
        }

    }
}
