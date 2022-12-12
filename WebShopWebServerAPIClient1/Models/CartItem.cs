
using WebShop.Models;

public class CartItem
        {
                public int ProductId { get; set; }
                public string ProductName { get; set; }
                public int Quantity { get; set; }
                public float Price { get; set; }
                public float Total
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

