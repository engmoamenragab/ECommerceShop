using ECommerceShop.BL.ViewModels;
using ECommerceShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.BL.Interfaces
{
    public interface IProductRepo
    {
        // Without Auto Mapper
        //public void Create(ProductVM model);
        //public IEnumerable<ProductVM> ReadAll();
        //public ProductVM Read(int id);
        //public void Update(ProductVM model);
        //public void Delete(ProductVM model);

        // With AutoMapper
        public void Create(Product model);
        public IEnumerable<Product> ReadAll();
        public Product Read(int id);
        public void Update(Product model);
        public void Delete(Product model);
        public int InStockProduct(int id);
    }
}
