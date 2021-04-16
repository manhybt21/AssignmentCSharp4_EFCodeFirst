using AssignmentCSharp4_EFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Context
{
    public class DatabaseContext: DbContext

    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public DbSet<AssignmentCSharp4_EFCodeFirst.Models.Account> Account { get; set; }
        //public DbSet<Cart> carts { get; set; }
        //public DbSet<Cart_Details> Cart_Details { get; set; }
    }
}
