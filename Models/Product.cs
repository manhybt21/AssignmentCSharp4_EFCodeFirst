using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        [Required]
        [StringLength(50)]
        public string NameProduct { get; set; }
        [Display(Name = "Giá")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
        [Display(Name = "Mô Tả")]
        [StringLength(200)]
        public string Desciption { get; set; }
        [Display(Name = "Ảnh")]
        [StringLength(200)]
        public string Image { get; set; }
        [ForeignKey("CattegoryId")]
        [Display(Name ="Danh Mục")]
        public int CategoryId { set; get; }
    }
}