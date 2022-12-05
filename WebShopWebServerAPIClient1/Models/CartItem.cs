using WebShopModel.Model;

namespace ShoppingCart.Models
{
        public class CartItem
        {
                public long ProductId { get; set; }
                public string ProductName { get; set; }
                public int Quantity { get; set; }
                public double Price { get; set; }
                public double Total
                {
                        get { return Quantity * Price; }
                }
                public string Image { get; set; }

                public CartItem()
                {
                }

                public CartItem(Product product)
                {
                        ProductId = product.ID;
                        ProductName = product.Name;
                        Price = product.Price;
                        Quantity = 1;
                       
                }

        }
}
