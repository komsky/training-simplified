using Simple.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Color { get; set; }
        public decimal Price { get; set; }
        //TODO: 02 Change display name
        //[DisplayName("Date Added")]
        public DateTime DateAdded { get; set; }
        //TODO: 02 Change display name
        //[DisplayName("Customer")]
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}
