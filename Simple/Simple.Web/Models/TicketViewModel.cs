using Simple.DAL.Entities;
using Simple.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Web.Models
{
    public class TicketViewModel
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        [DisplayName("Ticket Priority")]
        public TicketPriority TicketPriority { get; set; }
        [DisplayName("Ticket State")]
        public TicketState TicketState { get; set; }
        [DisplayName("Product")]
        public int? ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public String AgentReply { get; set; }
        [DisplayName("Owner")]
        public String OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        [DisplayName("Agent")]
        public String AssignedAgentId { get; set; }
        public ApplicationUser AssignedAgent { get; set; }
    }
}
