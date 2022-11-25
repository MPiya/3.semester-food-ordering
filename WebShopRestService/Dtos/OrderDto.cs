namespace WebShopService.Dtos
{
    public class OrderDto
    {





        public OrderDto(int id, int customerId, DateTime date)
        {
            this.ID = id;
            this.customerId = customerId;
            this.orderDate = date;

        }


        public int ID { get; set; }

        public int customerId { get; set; }
        public DateTime orderDate { get; set; }
        //public DateTime Datetime { get; set; }


    }
}
