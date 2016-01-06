using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Simple.DAL.Entities;

namespace Simple.Web.Models.Factories
{
    public static class TicketFactories
    {
        public static TicketViewModel CreateTicketViewModel(Ticket ticket)
        {
            return Mapper.DynamicMap<TicketViewModel>(ticket);
        }
        public static TicketViewModel ToTicketViewModel(this Ticket ticket)
        {
            return CreateTicketViewModel(ticket);
        }

        public static Ticket CreateTicket(TicketViewModel ticketViewModel)
        {
            return Mapper.DynamicMap<Ticket>(ticketViewModel);
        }
        public static Ticket ToTicket(this TicketViewModel ticketViewModel)
        {
            return CreateTicket(ticketViewModel);
        }
    }
}