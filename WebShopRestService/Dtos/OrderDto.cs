namespace RestAPI.Dtos
{
    public class OrderDto
    {
        public OrderDto(int id, int customerId, DateTime date)
        {
            this.ID = id;
            this.customerID = customerId;
            this.orderDate = date;

        }
        public OrderDto() { }
        public OrderDto(int customerId, DateTime date)
        {

            this.customerID = customerId;
            this.orderDate = date;

        }
        public int ID { get; set; }

        public int customerID { get; set; }
        public DateTime orderDate { get; set; }



    }
}
