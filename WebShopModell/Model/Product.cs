using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopModel.Model
{
    public class Product
    {

        public Product() { }
        public Product(string? name, double price, string? image, int stockQuantity, bool isStock, String? discription)
        {
            this.Name = name;
            this.Price = price;
            this.Image = image;
            this.StockQuantity = stockQuantity;
            this.IsStock = isStock;
            this.Discription = discription;

        }
        public Product(int id, string? name, double price, string? image, int stockQuantity, bool isStock, String? discription) : 
            this(name, price, image, stockQuantity, isStock, discription)
        {
            Id = id;
        }



        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public int StockQuantity { get; set; }

        public bool IsStock { get; set; }
        public string? Discription { get; set; }


        public bool IsProductEmpty
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Name))
                { return true; }
                else
                {
                    return false;
                }
            }

        }

    }
}