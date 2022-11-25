using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopWebServerAPIClient1.Data;

namespace WebShopModel.Model
{
    public class OrderLine
    {

        public AppDbContext _context { get; set; }

        public OrderLine(AppDbContext context)
        {
            _context = context;
        }

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

        public List<Product> Products { get; set; }

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