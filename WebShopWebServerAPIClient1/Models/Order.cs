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
        /*
        public Order(int id, int customerId, DateTime date) { 
            this.ID= id;
            this.customerId = customerId;
            this.orderDate= date;
        
        }*/


        public Order( int customerId, DateTime date)
        {
          
            this.customerId = customerId;
            this.orderDate = date;

        }

        public Order(Customer customer, DateTime date)
        {

            this.customerId = customer.Id;
            this.orderDate = date;

        }


        public int ID { get; set; }

        public int customerId { get; set; }
        public DateTime orderDate { get; set; }


        public Order(int tempOrderId, string tempCustomerName, DateTime tempDate)
        {
            TempOrderId = tempOrderId;
            TempCustomerName = tempCustomerName;
            TempDate = tempDate;
        }
        public Order(int tempOrderId, int id, DateTime tempDate)
        {
            TempOrderId = tempOrderId;
            customerId = id;
            TempDate = tempDate;
        }

        public int TempOrderId { get; }
        public string TempCustomerName { get; }
        public DateTime TempDate { get; }


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
    }

}
