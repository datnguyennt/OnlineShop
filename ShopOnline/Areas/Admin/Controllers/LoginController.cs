using Models.DAO;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            var session = Session[Constants.USER_SEESION];
            if (session != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        // GET: Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserLoginDAO();
                var result = dao.LoginUser(model.UserName, Encryptor.MD5Hash(model.UserPassword));
                if (result == 1)
                {
                    //ModelState.AddModelError("","Login Successfully");
                    Session.Add(Constants.USER_SEESION, model.UserName);
                    Session["UserName"] = model.UserName.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai ");
                }
            }
            return View("Index");
        }
    }
}