using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Simple.DAL.Context;
using Simple.DAL.Entities;
using Simple.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Simple.Web.Tests.Controllers
{
    [TestClass]
    public class TicketControllerTest
    {
        [TestMethod]
        public void DetailsTest()
        {
            // Arrange
            List<Ticket> lista = GetFakeTickets();

            var dbTicketMock = new Mock<DbSet<Ticket>>();
            dbTicketMock.As<IQueryable<Ticket>>().Setup(m => m.Provider).Returns(lista.AsQueryable().Provider);
            dbTicketMock.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(lista.AsQueryable().Expression);
            dbTicketMock.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(lista.AsQueryable().ElementType);
            dbTicketMock.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(lista.AsQueryable().GetEnumerator());
            dbTicketMock.Setup(m => m.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => lista.FirstOrDefault(x=>x.Id == (int)ids[0]));
            
            var dbContextMock = new Mock<ApplicationDbContext>();
            dbContextMock.SetupGet<DbSet<Ticket>>(x => x.Tickets)
                .Returns(dbTicketMock.Object);

            TicketsController controller = new TicketsController(dbContextMock.Object);

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        private static List<Ticket> GetFakeTickets()
        {
            List<Ticket> lista = new List<Ticket>
                { new Ticket
                {
                    Id =1, 
                    Title = "Fake", 
                    Description = "FakeDescription",
                TicketPriority = DAL.Enums.TicketPriority.High,
                TicketState = DAL.Enums.TicketState.Created
                }
            };
            return lista;
        }
    }
}
