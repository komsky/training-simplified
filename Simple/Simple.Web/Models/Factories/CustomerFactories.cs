using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Simple.DAL.Entities;

namespace Simple.Web.Models.Factories
{
    public static class CustomerFactories
    {
        public static CustomerViewModel CreateCustomerViewModel(Customer customer)
        {
            return Mapper.DynamicMap<CustomerViewModel>(customer);
        }
        public static CustomerViewModel ToCustomerViewModel(this Customer customer)
        {
            return CreateCustomerViewModel(customer);
        }

        public static Customer CreateCustomer(CustomerViewModel customerViewModel)
        {
            return Mapper.DynamicMap<Customer>(customerViewModel);
        }
        public static Customer ToCustomer(this CustomerViewModel customerViewModel)
        {
            return CreateCustomer(customerViewModel);
        }
    }
}