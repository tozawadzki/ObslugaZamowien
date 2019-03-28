using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObslugaZamowien
{
    public class Order
    {
        [StringLength(6)]
        public string ClientID { get; set; }
        public long RequestID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
