using AutoMapper;
using ECommerceShop.BL.Interfaces;
using ECommerceShop.DAL.Database;
using ECommerceShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.BL.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        #region Fields
        private readonly ECommerceShopDbContext db;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public CustomerRepo(ECommerceShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        #endregion

        #region Create Method
        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="model"></param>
        public void Create(Customer model)
        {
            db.Customers.Add(model);
            db.SaveChanges();
        }
        #endregion

        #region Read All Method
        /// <summary>
        /// Read all customers
        /// </summary>
        /// <param></param>
        public IEnumerable<Customer> ReadAll()
        {
            var data = db.Customers.Select(C => C);
            return data;
        }
        #endregion

        #region Read Method
        /// <summary>
        /// Read customer by id
        /// </summary>
        /// <param name="id"></param>
        public Customer Read(int id)
        {
            var data = db.Customers.Include(C => C.Orders).Where(C => C.Id == id).FirstOrDefault();
            return data;
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="model"></param>
        public void Update(Customer model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region Delete Method
        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="model"></param>
        public void Delete(Customer model)
        {
            db.Customers.Remove(model);
            db.SaveChanges();
        }
        #endregion

        #region Ajax Requests
        public IEnumerable<Product> ProductByCustomerId(int custId)
        {
            var data = db.Customers.Where(C => C.Id == custId).Join
                (
                    db.OrderProducts,
                    C => C.Id,
                    P => P.Order.CustomerId,
                    (C, P) => new Product()
                    {
                        Id = P.Product.Id,
                        Color = P.Product.Color,
                        Name = P.Product.Name,
                        Price = P.Product.Price,
                        Description = P.Product.Description,
                        Size = P.Product.Size,
                        Quantity = P.Product.Quantity,
                        ProductUser = P.Product.ProductUser
                    }
                );
            return data;
        }
        #endregion
    }
}
