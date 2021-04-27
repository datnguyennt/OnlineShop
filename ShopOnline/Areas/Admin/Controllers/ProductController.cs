using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new ProductDAO();
            var model = dao.ListAllPaging(page, pageSize);


            return View(model);
        }
    }
}