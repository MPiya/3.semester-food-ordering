namespace RestAPI.Dtos
{
    public class OrderLineDto
    {
        public OrderLineDto() { }


        public OrderLineDto(int productID, int orderID, int saleQuantity, double totalPrice)
        {
            this.ProductID = productID;
            this.OrderID = orderID;
            this.Quantity = saleQuantity;
            this.TotalPrice = totalPrice;
        }

        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }

}
