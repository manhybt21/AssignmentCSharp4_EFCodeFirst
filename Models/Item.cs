using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Models
{
    public class Item
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
