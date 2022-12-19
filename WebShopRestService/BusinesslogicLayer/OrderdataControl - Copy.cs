using Microsoft.AspNetCore.Mvc;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;

namespace WebShopService.BusinesslogicLayer
{
    public class OrderLineDataControl : IOrderLinedata
    {
        IOrderLineAccess _orderLineAccess;
        
        public OrderLineDataControl(IConfiguration inConfiguration)
        {
            _orderLineAccess = new OrderLineDatabaseAccess(inConfiguration);
        }
        

        public int Create(OrderLine newOrderLine)
        {
            int insertId;
        
            try
            {
                insertId = _orderLineAccess.CreateOrderLine(newOrderLine);
               

            }
            catch
            {

                insertId = -1;
            
            }
            return insertId;
        }

        }

      


}
