namespace RestAPI.Dtos
{
    public class OrderDto
    {
        public OrderDto(int customerId, DateTime date)
        {

            this.customerId = customerId;
            orderDate = date;

        }

        public OrderDto(int id, int customerId, DateTime date)
        {
            id = Orderid;
            this.customerId = customerId;
            orderDate = date;

        }

        public int Orderid { get; set; }
        public int customerId { get; set; }
        public DateTime orderDate { get; set; }
     


    }
}
