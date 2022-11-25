namespace WebShopService.Dtos
{
    public class ProductDto
    {

        public ProductDto() { }
        public ProductDto(int id, string? name, double price, string? image, int stockQuantity, bool isStock)
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

    }
}
