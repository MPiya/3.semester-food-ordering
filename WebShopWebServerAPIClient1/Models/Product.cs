using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Product
    {

        public Product() { }
        public Product(int id, string? name,  float price, string? image, int stockQuantity, bool isStock)
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
        public float Price { get; set; }
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