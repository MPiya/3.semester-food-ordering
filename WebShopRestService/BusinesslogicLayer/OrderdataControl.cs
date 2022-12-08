using Microsoft.AspNetCore.Mvc;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;

namespace RESTAPI.BusinesslogicLayer { 
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
            
            try
            {
                insertId = _orderAccess.CreateOrder(newOrder);
                

            }
            catch
            {

                insertId = -1;
               
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
