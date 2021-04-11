using ShopOnline.Common;
using ShopOnline.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var session = Session[Constants.USER_SEESION];
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            
            return View();
        }
        public ActionResult Logout()
        {
            Session[Constants.USER_SEESION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}