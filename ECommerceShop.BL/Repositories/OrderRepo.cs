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
    public class OrderRepo : IOrderRepo
    {
        #region Fields
        private readonly ECommerceShopDbContext db;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public OrderRepo(ECommerceShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        #endregion

        #region Create Method
        /// <summary>
        /// Create new order
        /// </summary>
        /// <param name="model"></param>
        public Order Create(Order model)
        {
            db.Orders.Add(model);
            db.SaveChanges();
            return model;
        }
        #endregion

        #region Read All Method
        /// <summary>
        /// Read all orders
        /// </summary>
        /// <param></param>
        public IEnumerable<Order> ReadAll()
        {
            var data = db.Orders.Include(C => C.Customer).Include(C => C.OrderProducts).ThenInclude(C => C.Product).Select(C => C);
            return data;
        }
        #endregion

        #region Read Method
        /// <summary>
        /// Read order by id
        /// </summary>
        /// <param name="id"></param>
        public Order Read(int id)
        {
            var data = db.Orders.Include(O => O.Customer).Where(O => O.Id == id).FirstOrDefault();
            return data;
        }
        #endregion

        #region Delete Method
        /// <summary>
        /// Delete order
        /// </summary>
        /// <param name="model"></param>
        public void Delete(Order model)
        {
            db.Orders.Remove(model);
            db.SaveChanges();
        }
        #endregion

        #region Count
        /// <summary>
        /// Count of orders
        /// </summary>
        /// <param name="model"></param>
        public int Count()
        {
            var count = db.Orders.Count();
            return count;
        }
        #endregion
    }
}
