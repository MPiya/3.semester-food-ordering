using Microsoft.AspNetCore.Mvc;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;

namespace WebShopService.BusinesslogicLayer
{
    public class OrderdataControl : IOrderdata
    {
        IOrderAccess _orderAccess;
        
        public OrderdataControl(IConfiguration inConfiguration)
        {
            _orderAccess = new OrderDatabaseAccess(inConfiguration);
        }
        

        public int Add(Order newOrder)
        {
            int insertId;
            DateTime insertedDateTime = DateTime.Now;
            try
            {
                insertId = _orderAccess.CreateOrder(newOrder);
                insertedDateTime = insertedDateTime.AddYears(1).AddMonths(1).AddDays(1).AddHours(1).AddMinutes(1);

            }
            catch
            {

                insertId = -1;
                insertedDateTime = DateTime.Now;
            }
            return insertId;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order? Get(int idToMatch)
        {
            Order? foundOrders;
            try
            {
                foundOrders = _orderAccess.GetOrderById(idToMatch);
            }
            catch
            {
                foundOrders = null;
            }
            return foundOrders;
        }

        public List<Order>? Get()
        {
            List<Order>? foundOrders;
            try
            {
                foundOrders = _orderAccess.GetOrderAll();

            }
            catch
            {
                foundOrders = null;
            }

            return foundOrders;

        }

        

        public bool Put(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
