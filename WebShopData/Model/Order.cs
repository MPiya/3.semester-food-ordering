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

        public Order(int id, int customerId, DateTime date) { 
            this.ID= id;
            this.customerId = customerId;
            this.orderDate= date;
        
        }
        public Order( int customerId, DateTime date)
        {
        
            this.customerId = customerId;
            this.orderDate = date;

        }

<<<<<<< HEAD
        public Order(int tempOrderId, string tempCustomerName, DateTime tempDate)
        {
            TempOrderId = tempOrderId;
            TempCustomerName = tempCustomerName;
            TempDate = tempDate;
        }
=======


        public int ID { get; set; }
>>>>>>> parent of def5651 (Fix Name Space in RESTAPI project)

        public int ID { get; set; }
        public int customerId { get; set; }
        public DateTime orderDate { get; set; }

        public List<OrderLine> Lines { get; set; }

<<<<<<< HEAD
        public int TempOrderId { get; }
        public string TempCustomerName { get; }
        public DateTime TempDate { get; }
=======
        public virtual Customer Customer { get; set; } = null!;

        /*
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
        */

        /*
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
            }*/
>>>>>>> parent of def5651 (Fix Name Space in RESTAPI project)
    }

}
