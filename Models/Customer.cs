using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name="Họ Và Tên")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Ngày Sinh")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Số Điện Thoại")]
        [StringLength(13)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Địa Chỉ")]
        [StringLength(50)]
        public string Address { get; set; }
        [Display(Name = "Email")]
        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Display(Name = "Mật Khẩu")]
        [StringLength(30)]
        [Required]
        public string Password { get; set; }
        //[Display(Name = "Nhập Lại Mật Khẩu")]
        //[StringLength(30)]
        //[Required]
        //public string ConfirmPassword { get; set; }

    }
}
