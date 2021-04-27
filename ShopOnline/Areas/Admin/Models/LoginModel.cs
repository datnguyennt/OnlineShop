using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Models
{
    public class LoginModel
    {
        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống username")]
        public string UserName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Không được để trống mật khẩu")]
        public string UserPassword { get; set; }
        public bool RemmemberMe { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}