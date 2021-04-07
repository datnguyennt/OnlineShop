namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginUser")]
    public partial class LoginUser
    {
        [Key]
        [StringLength(50)]
        [Display(Name ="Tên đăng nhập")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Mật khẩu")]
        public string UserPassword { get; set; }
    }
}
