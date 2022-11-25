using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebShopModel.Model
{
    public class OrderLine
    {
        public OrderLine() { }

        public OrderLine(int productID, int orderID, int saleQuantity, double totalPrice)
        {
            this.ProductID= productID;
            this.OrderID = orderID;
            this.Quantity = saleQuantity;
            this.TotalPrice = totalPrice;
        }

        public int ProductID{ get; set; }

        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice{ get; set; }
    }
}