using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.DAL.Entities
{
    public class Order
    {
        #region Constructors
        public Order()
        {
            this.OrderTime = DateTime.Now;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        #endregion
    }
}
