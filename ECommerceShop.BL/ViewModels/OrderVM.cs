using ECommerceShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.BL.ViewModels
{
    public class OrderVM
    {
        #region Properties
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public IEnumerable<int> ProductId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        #endregion
    }
}
