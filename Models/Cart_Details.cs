using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Models
{
    [Table("Cart_Details")]
    public class Cart_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalMoney { get; set; }
        public Cart cart { get; set; }
    }
}
