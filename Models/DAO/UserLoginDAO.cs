using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PagedList;

namespace Models.DAO
{
    public class UserLoginDAO
    {
        WebDbContext db = null;

        public UserLoginDAO()
        {
            db = new WebDbContext();
        }

        public int LoginUser(String UserName, String UserPassword)
        {
            var result = db.User.SingleOrDefault(x => x.Username == UserName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == UserPassword)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public long Insert(User loginUser)
        {
            db.User.Add(loginUser);
            db.SaveChanges();
            return loginUser.UserID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.UserID);
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public int GetById(string userName)
        {
            var result = db.User.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public User GetByID(string userName)
        {
            return db.User.SingleOrDefault(x => x.Username.Contains(userName));
        }

        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }
        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.User.ToPagedList(page, pageSize);
        }

        public List<User> ListAll()
        {
            return db.User.ToList();
        }

    }
}
