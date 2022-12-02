using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebShopModel.Model;

namespace WebShop.Models
{
    public class ShoppingCart
    {


        public ShoppingCart(int shopId,int pId, int count)
        {
            ShoppingCartId=shopId;
            ProductId = pId;
            Count =count;
        }

        public ShoppingCart() { }

        public ShoppingCart(int count, string menu, double price)
        {
            this.Count = count;
            this.menu = menu;
            this.Price = price;

        }
       
        public int ShoppingCartId
        {
            get; set;

        }
        [Key]
        public int ProductId { get; set; }

        public string menu { get; set; }

        [ForeignKey("ProductId")]
        public Product Product  { get; set; }

        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }


        [NotMapped]
        public double Price { get; set; }
        


    }
}