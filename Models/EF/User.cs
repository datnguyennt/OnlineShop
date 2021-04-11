namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int UserID { get; set; }

        [StringLength(10, ErrorMessage = "Chỉ nhập tối đa 10 kí tự")]
        [Required]
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }

        [StringLength(32, ErrorMessage = "Chỉ nhập 32 kí tự")]
        [Required]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "Chỉ nhập tối đa 50 kí tự")]
        [Required]
        [DisplayName("Tên")]
        public string FirstName { get; set; }


        [StringLength(50, ErrorMessage = "Chỉ nhập tối đa 50 kí tự")]
        [Required]
        [DisplayName("Họ và tên đệm")]
        public string LastName { get; set; }

        [StringLength(250)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [DisplayName("Địa chỉ email")]
        public string Email { get; set; }

        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng thái tài khoản")]
        public bool Status { get; set; }
    }
}
