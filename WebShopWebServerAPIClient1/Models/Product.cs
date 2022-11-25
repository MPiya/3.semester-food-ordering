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
        public Product(int id, string? name, double price, string? image, int stockQuantity, bool isStock)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Image = image;
            this.StockQuantity = stockQuantity;
            this.IsStock = isStock;


        }




        public int ID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public int StockQuantity { get; set; }

        public bool IsStock { get; set; }
       


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