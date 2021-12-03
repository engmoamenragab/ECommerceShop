using AutoMapper;
using ECommerceShop.BL.ViewModels;
using ECommerceShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.BL.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();

            CreateMap<Customer, CustomerVM>();
            CreateMap<CustomerVM, Customer>();

            CreateMap<Order, OrderVM>();
            CreateMap<OrderVM, Order>();

            CreateMap<OrderProduct, OrderProductVM>();
            CreateMap<OrderProductVM, OrderProduct>();
        }
    }
}
