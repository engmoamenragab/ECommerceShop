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
    public class OrderProductRepo : IOrderProductRepo
    {
        #region Fields
        private readonly ECommerceShopDbContext db;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public OrderProductRepo(ECommerceShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        #endregion

        #region Create Method
        /// <summary>
        /// Create new orderProduct
        /// </summary>
        /// <param name="model"></param>
        public void Create(OrderProduct model)
        {
            var data = new OrderProduct() { OrderId = model.OrderId, ProductId = model.ProductId };
            db.OrderProducts.Add(data);
            db.SaveChanges();
        }
        #endregion

        #region Read All Method
        /// <summary>
        /// Read all orderProducts
        /// </summary>
        /// <param></param>
        public IEnumerable<OrderProduct> ReadAll()
        {
            var data = db.OrderProducts.Select(C => C);
            return data;
        }
        #endregion

        #region Read Method
        /// <summary>
        /// Read orderProduct by id
        /// </summary>
        /// <param name="id"></param>
        public OrderProduct Read(int id)
        {
            var data = db.OrderProducts.Where(C => C.OrderId == id).FirstOrDefault();
            return data;
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Update orderProduct
        /// </summary>
        /// <param name="model"></param>
        public void Update(OrderProduct model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region Delete Method
        /// <summary>
        /// Delete orderProduct
        /// </summary>
        /// <param name="model"></param>
        public void Delete(OrderProduct model)
        {
            db.OrderProducts.Remove(model);
            db.SaveChanges();
        }
        #endregion
    }
}
