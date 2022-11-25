using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopModel.Model
{

    public class Order
    {
        public Order() { }

        public Order(int customerId, string? paymentType, string? notes)
        {
            this.customerId = customerId;
            this.paymentType = paymentType;
            this.notes = notes;
        }

        public Order(DateTime orderDate, int customerId, string? paymentType, string? notes)
        {
            this.orderDate = orderDate;
            this.customerId = customerId;
            this.paymentType = paymentType;
            this.notes = notes;
        }

        public Order(int id, DateTime orderDate, int customerId, string? paymentType, string? notes)
            : this(customerId, paymentType, notes)
        {
            this.id = id;
            this.orderDate = orderDate;
        }

        public int id { get; set; }
        public DateTime orderDate { get; set; }

        public int customerId { get; set; }
        public string? paymentType { get; set; }
        public string? notes { get; set; }

        public bool IsOrderEmpty
        {
            get
            {
                if (String.IsNullOrWhiteSpace(paymentType))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}


