using ECommerceShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.BL.Interfaces
{
    public interface ICustomerRepo
    {
        public void Create(Customer model);
        public IEnumerable<Customer> ReadAll();
        public Customer Read(int id);
        public void Update(Customer model);
        public void Delete(Customer model);
        public IEnumerable<Product> ProductByCustomerId(int custId);
    }
}
