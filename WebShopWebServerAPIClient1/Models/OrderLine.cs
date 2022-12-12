using MessagePack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebShop.Models
{
    [Keyless]
    public class OrderLine
    {

      
        public int ProductID { get; set; }
     
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        List<Product> products1= new List<Product>();


        public OrderLine(int productID, int orderID, int saleQuantity, double totalPrice)
        {
            this.ProductID = productID;
            this.OrderID = orderID;
            this.Quantity = saleQuantity;
            this.TotalPrice = totalPrice;

        }

        public OrderLine()
        {

        }


        public OrderLine(int productID)
        {
            this.ProductID = productID;

            List<Product> product = new List<Product>();
        }

        public OrderLine(List<Product> products)
        {
            products1 = products;
        }





        /*
        public List<Product> getProducts()
        {
            return Products ?? (OrderLine = _context.OrderLine.wheree)
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
        }*/
    }
}