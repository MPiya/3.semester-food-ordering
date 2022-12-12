namespace RestAPI.Dtos
{
    public class OrderDto
    {
        public OrderDto() { }
        public OrderDto(int id, int customerId, DateTime date)
        {
            this.ID = id;
            this.customerID = customerId;
            this.orderDate = date;

        }
     
        public OrderDto(int customerId, DateTime date)
        {

            this.customerID = customerId;
            this.orderDate = date;

        }

        public OrderDto(int id, string name, DateTime date)
        {
            ID = id;
            Name = name;
            orderDate = date;

        }

        public string? Name { get; set; }
        public int ID { get; set; }

        public int customerID { get; set; }
        public DateTime orderDate { get; set; }



    }
}
