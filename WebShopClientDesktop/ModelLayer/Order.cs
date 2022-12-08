using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopClientDesktop.ModelLayer
{
    public class Order
    {
       	public Order() { }
		 

		public Order(DateTime orderDate, int customerId, string paymentType, string notes)
		{
			orderDate = orderDate;
			customerId = customerId;
			paymentType = paymentType;
			notes = notes;
	
		}

		public Order(DateTime orderDate, string customerId, string paymentType, string notes, string fullOrder)
		
		{
			
			customerId = customerId;
			orderDate = orderDate.ToUniversalTime();
			paymentType = paymentType;
			notes = notes;
			fullOrder= fullOrder;
		}

        public Order(int orderId, string? customerName, DateTime orderDate)
        {
            ID = orderId;
            CustomerName = customerName;
            OrderDate = orderDate;


        }

        public int ID { get; set; }
        public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        public string customerName { get; set; }	
        public int customerId { get; set; }
		public string? paymentType { get; set; }
		public string? notes { get; set; }
		public DateTime orderDate { get; set; }
		
		
		
		
	

		public override string ToString()
		{
			//string? oText = fullOrder;
			//int otext1 = customerId.CompareTo(customerId.TryFormat());
			
			DateTime oText3 = orderDate;
            string orderID = ID.ToString();
            string date = oText3.ToString();
			string customerid = customerId.ToString();
			string customerName1 = customerName.ToString();


			//if (paymentType != null)
			//{
			//	oText += " - paymentType: " + paymentType;
			//}
			//}
			//return OrderID +  "  "  + customerid +  "  "  + date  + "  " ; 
			return orderID + "   " + customerName1 + "   " + date + "  ";
		}

    }
}
