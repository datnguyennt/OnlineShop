using Models.DAO;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Common;
using ShopOnline.Extensions;
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
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.UserID;
                    userSession.FirstName = user.FirstName;
                    Session.Add(Constants.USER_SEESION, userSession);
                    Session["UserName"] = user.LastName + " "+ user.FirstName;
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    this.AddNotification("Tài khoản không tồn tại", NotificationType.ERROR);
                }
                else if (result == -1)
                {
                    this.AddNotification("Tài khoản đang bị khóa", NotificationType.ERROR);
                }
                else if (result == -2)
                {
                    this.AddNotification("Sai mật khẩu", NotificationType.ERROR);

                }else
                {
                    this.AddNotification("Sai tên đăng nhập", NotificationType.ERROR);
                }
            }
            return View("Index");
        }
    }
}