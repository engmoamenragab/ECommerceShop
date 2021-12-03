using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ECommerceShop.DAL.Database;
using ECommerceShop.DAL.Entities;
using ECommerceShop.BL.Interfaces;
using ECommerceShop.BL.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ECommerceShop.BL.Repositories
{
    public class ProductRepo : IProductRepo
    {
        //ECommerceShopDbContext db = new ECommerceShopDbContext();

        #region Fields
        private readonly ECommerceShopDbContext db;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public ProductRepo(ECommerceShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        #endregion

        #region Create Method
        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="model"></param>
        public void Create(Product model)
        {
            //Product product = new Product()
            //{
            //    Id = model.Id,
            //    Name = model.Name,
            //    Description = model.Description,
            //    Color = model.Color,
            //    Size = model.Size,
            //    Price = model.Price,
            //    Quantity = model.Quantity,
            //    ProductUser = model.ProductUser
            //};
            db.Products.Add(model);
            db.SaveChanges();
        }
        #endregion

        #region Read All Method
        /// <summary>
        /// Read all products
        /// </summary>
        /// <param></param>
        public IEnumerable<Product> ReadAll()
        {
            var data = db.Products.Select(P => P);
            //new ProductVM()
            //{
            //    Id = P.Id,
            //    Name = P.Name,
            //    Description = P.Description,
            //    Color = P.Color,
            //    Size = P.Size,
            //    Price = P.Price,
            //    Quantity = P.Quantity,
            //    ProductUser = P.ProductUser
            //});
            return data;
        }
        #endregion

        #region Read Method
        /// <summary>
        /// Read product by id
        /// </summary>
        /// <param name="id"></param>
        public Product Read(int id)
        {
            var data = db.Products.Where(P => P.Id == id).FirstOrDefault();
            //ProductVM product = new ProductVM()
            //{
            //    Id = data.Id,
            //    Name = data.Name,
            //    Description = data.Description,
            //    Color = data.Color,
            //    Size = data.Size,
            //    Price = data.Price,
            //    Quantity = data.Quantity,
            //    ProductUser = data.ProductUser
            //};
            return data;
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="model"></param>
        public void Update(Product model)
        {
            //Product product = new Product()
            //{
            //    Id = model.Id,
            //    Name = model.Name,
            //    Description = model.Description,
            //    Color = model.Color,
            //    Size = model.Size,
            //    Price = model.Price,
            //    Quantity = model.Quantity,
            //    ProductUser = model.ProductUser
            //};
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        #region Delete Method
        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="model"></param>
        public void Delete(Product model)
        {
            //Product product = new Product()
            //{
            //    Id = model.Id,
            //    Name = model.Name,
            //    Description = model.Description,
            //    Color = model.Color,
            //    Size = model.Size,
            //    Price = model.Price,
            //    Quantity = model.Quantity,
            //    ProductUser = model.ProductUser
            //};
            db.Products.Remove(model);
            db.SaveChanges();
        }
        #endregion

        #region Ajax Requests
        public int InStockProduct(int id)
        {
            var data = db.Products.Where(P => P.Id == id).Select(P => P.Quantity).FirstOrDefault();
            return data;
        }
        #endregion
    }
}
