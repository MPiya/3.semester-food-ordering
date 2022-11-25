using WebShopModel.Model;
using WebShopService.Dtos;



namespace WebShopService.ModelConversion

{
    public class OrderDtoConvert
    {
        public static List<OrderDto>? FromOrderCollection(List<Order> inOrders)
        {

            List<OrderDto>? aOrderReadDtoList = null;
            if (inOrders != null)
            {
                aOrderReadDtoList = new List<OrderDto>();
                OrderDto tempDto;
                foreach (Order aOrder in inOrders)
                {
                    if (aOrder != null)
                    {

                        tempDto = FromOrder(aOrder);
                        aOrderReadDtoList.Add(tempDto);
                    }
                }
            }
            return aOrderReadDtoList;
        }
        public static OrderDto? FromOrder(Order inOrder)
        {
            OrderDto? aOrderReadDto = null;
            if (inOrder != null)
            {
                aOrderReadDto = new OrderDto(inOrder.ID, inOrder.customerId, inOrder.orderDate);
                //aOrderReadDto.FullOrder = $"{inOrder.customerId} {inOrder.paymentType} {inOrder.notes} {inOrder.orderDate} {inOrder.id}";
            }
            return aOrderReadDto;
        }
        public static Order? ToOrder(OrderDto inDto)
        {
            Order? aOrder = null;
            if(inDto != null)
            {
                aOrder = new Order(inDto.customerId, inDto.customerId, inDto.orderDate);
            }
            return aOrder;
        }

    }

}