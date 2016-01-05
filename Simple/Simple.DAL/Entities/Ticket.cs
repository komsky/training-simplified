using Simple.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.DAL.Entities
{
    public class Ticket
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketState TicketState { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public String AgentReply { get; set; }
        [ForeignKey("Owner")]
        public String OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        [ForeignKey("AssignedAgent")]
        public String AssignedAgentId { get; set; }
        public ApplicationUser AssignedAgent { get; set; }
    }
}
