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

		public int customerId { get; set; }
		public string? paymentType { get; set; }
		public string? notes { get; set; }
		public DateTime orderDate { get; set; }
		public string? fullOrder { get; set; }

		public override string ToString()
		{
			//string? oText = fullOrder;
			//int otext1 = customerId.CompareTo(customerId.TryFormat());
			string? oText2 = notes;
			DateTime oText3 = orderDate;
			string? oText4 = paymentType; ;

			//if (paymentType != null)
			//{
			//	oText += " - paymentType: " + paymentType;
			//}
			return oText2 + oText3 + oText4;
		}

    }
}
