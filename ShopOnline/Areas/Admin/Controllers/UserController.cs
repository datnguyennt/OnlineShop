using Models.DAO;
using Models.EF;
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
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserLoginDAO();

                var pass = Encryptor.MD5Hash(model.Password);
                model.Password = pass;
                var result = dao.GetById(model.Username);
                if (result == 1)
                {
                    this.AddNotification("Tài khoản bị trùng", NotificationType.ERROR);

                }
                else
                {
                    long id = dao.Insert(model);
                    if (id > 0)
                    {
                        this.AddNotification("Thêm người dùng thành công", NotificationType.SUCCESS);
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {

                        this.AddNotification("Thêm thất bại", NotificationType.ERROR);
                        //return RedirectToAction("Create", "User");
                    }
                }


            }
            return View("Create");
        }
    }
}