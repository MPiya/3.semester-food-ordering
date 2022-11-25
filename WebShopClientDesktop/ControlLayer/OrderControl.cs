using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopClientDesktop.ModelLayer;
using WebShopClientDesktop.ServiceLayer;

namespace WebShopClientDesktop.ControlLayer
{
    public class OrderControl
    {
        readonly IOrderAccess _oAccess;

        public OrderControl()
        {
            _oAccess = new OrderServiceAccess();
        }

        public async Task<List<Order>?> GetAllOrders()
        {
            List<Order>? foundOrders = null;
            if (_oAccess != null)
            {
                foundOrders = await _oAccess.GetOrders();
            }
            return foundOrders;
        }

        public async Task<int> SavePerson(string pment, string note, string custId)
        {
            Order newOrder = new(pment, note, custId);
            int insertedId = await _oAccess.SaveOrder(newOrder);
            return insertedId;
        }








    }
}
