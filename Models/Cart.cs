using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Models
{
    [Table("Cart")]
    public class Cart
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }  

       public int Quantity { get; set; }
       public decimal Amount { get; set; }
        public string NameProduct { get; set; }
        public decimal Price { get; set; }
       public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
