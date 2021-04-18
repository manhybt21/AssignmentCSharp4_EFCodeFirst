using AssignmentCSharp4_EFCodeFirst.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Services
{
    public class AccountServices
    {
        private readonly DatabaseContext _context;
        public void findAccount(string email, string password)
        {
            var find = _context.Customers.SingleOrDefault(x => x.Password == password && x.EmailAddress == email);
        }
        
    }
}
