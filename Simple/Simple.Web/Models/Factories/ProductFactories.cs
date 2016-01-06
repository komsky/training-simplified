using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Simple.DAL.Entities;

namespace Simple.Web.Models.Factories
{
    public static class ProductFactories
    {
        public static ProductViewModel CreateProductViewModel(Product product)
        {
            return Mapper.DynamicMap<ProductViewModel>(product);
        }
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return CreateProductViewModel(product);
        }

        public static Product CreateProduct(ProductViewModel productViewModel)
        {
            return Mapper.DynamicMap<Product>(productViewModel);
        }
        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            return CreateProduct(productViewModel);
        }
    }
}