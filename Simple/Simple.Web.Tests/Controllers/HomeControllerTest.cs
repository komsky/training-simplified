using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Web;
using Simple.Web.Controllers;
using Simple.DAL.Context;
using Moq;
using Simple.DAL.Entities;
using System.Data.Entity;

namespace Simple.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        Mock<DbSet<Ticket>> dbTicketMock;
        Mock<ApplicationDbContext> dbContextMock;
        public void TestSetup()
        {
            var customer = GetFakeCustomer();

            var product = GetFakeProduct(customer);
            // Arrange
            List<Ticket> ticketList = GetFakeTickets(product);


            dbTicketMock = new Mock<DbSet<Ticket>>();
            dbTicketMock.As<IQueryable<Ticket>>().Setup(m => m.Provider).Returns(ticketList.AsQueryable().Provider);
            dbTicketMock.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(ticketList.AsQueryable().Expression);
            dbTicketMock.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(ticketList.AsQueryable().ElementType);
            dbTicketMock.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(ticketList.AsQueryable().GetEnumerator());
            dbTicketMock.Setup(m => m.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => ticketList.FirstOrDefault(x => x.Id == (int)ids[0]));
            dbContextMock = new Mock<ApplicationDbContext>();

            dbContextMock.SetupGet<DbSet<Ticket>>(x => x.Tickets)
                .Returns(dbTicketMock.Object);
        }

        public void TestTeardown()
        {
            dbTicketMock = null;
            dbContextMock = null;
        }
        [TestMethod]
        public void IndexTest()
        {
            //arrange
            HomeController controller = new HomeController(dbContextMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AboutTest()
        {
            //arrange
            HomeController controller = new HomeController(dbContextMock.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        private static List<Ticket> GetFakeTickets(Product product)
        {
            List<Ticket> ticketList = new List<Ticket>
                { new Ticket
                    {
                        Id =1, 
                        Title = "Fake", 
                        Description = "FakeDescription",
                        TicketPriority = DAL.Enums.TicketPriority.High,
                        TicketState = DAL.Enums.TicketState.Created,
                        Product = product,
                        ProductId = product.Id
                    },
                    new Ticket
                    {
                        Id =2, 
                        Title = "Other Fake", 
                        Description = "FakeDescription",
                        TicketPriority = DAL.Enums.TicketPriority.Low,
                        TicketState = DAL.Enums.TicketState.InProgress
                    }
            };
            return ticketList;
        }

        private static Product GetFakeProduct(Customer customer)
        {
            var product = new Product
            {
                Id = 1,
                Name = "IoT",
                Customer = customer,
                CustomerId = customer.Id,
                Color = "Grey"
            };
            return product;
        }

        private static Customer GetFakeCustomer()
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "Adrian",
                Email = "customer@email.com",
                Address = "London,UK"
            };
            return customer;
        }

        
    }


}
