using ECommerceShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.BL.Interfaces
{
    public interface IOrderProductRepo
    {
        public void Create(OrderProduct model);
        public IEnumerable<OrderProduct> ReadAll();
        public OrderProduct Read(int id);
        public void Update(OrderProduct model);
        public void Delete(OrderProduct model);
    }
}
