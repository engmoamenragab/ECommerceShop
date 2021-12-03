using ECommerceShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.BL.Interfaces
{
    public interface IOrderRepo
    {
        public Order Create(Order model);
        public IEnumerable<Order> ReadAll();
        public Order Read(int id);
        public void Delete(Order model);
        public int Count();
    }
}
