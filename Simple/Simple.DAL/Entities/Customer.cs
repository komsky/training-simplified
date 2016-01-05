using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
