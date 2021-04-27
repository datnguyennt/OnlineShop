using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDAO
    {
        WebDbContext db = null;

        public ProductDAO()
        {
            db = new WebDbContext();
        }

        public int GetById(string codeProduct)
        {
            var result = db.Products.SingleOrDefault(x => x.ProductCode == codeProduct);
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public List<Products> ListAll()
        {
            return db.Products.ToList();
        }

        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            IQueryable<User> model = db.User;
            return model.OrderByDescending(x => x.UserID).ToPagedList(page, pageSize);
        }

    }
}
