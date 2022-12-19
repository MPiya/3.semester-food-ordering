using RestAPI.Dtos;
using WebShopModel.Model;




namespace RestAPI.ModelConversion

{
    public class OrderLineDtoConvert
    {
       
        public static OrderLine? ToOrderLine(OrderLineDto inDto)
        {
            OrderLine? aOrder = null;
            if (inDto != null)
            {
                aOrder = new OrderLine(inDto.ProductID, inDto.OrderID, inDto.Quantity,inDto.TotalPrice);
            }
            return aOrder;
        }

    }

}