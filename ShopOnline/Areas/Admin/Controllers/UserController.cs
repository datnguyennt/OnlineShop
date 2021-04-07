using Models.DAO;
using Models.EF;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            var user = new UserLoginDAO();
            var model = user.ListAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserLoginDAO();

                if (dao.Find(model.UserName) != null)
                {
                    return RedirectToAction("Create", "User");
                }

                var pass = Encryptor.MD5Hash(model.UserPassword);
                model.UserPassword = pass;
                var result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Tạo người dùng thành công", "warning");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("NGười dùng đã tồn tại, thử lại với tên khác", "warning");
                    //ModelState.AddModelError("", "Tạo người dùng không thành công");
                }
            }
            return View();
        }
    }
}