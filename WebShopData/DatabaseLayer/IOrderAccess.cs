using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopModel.Model;

namespace WebShopData.DatabaseLayer
{
    public interface IOrderAccess
    {
        Order GetOrderById(int ID);
        List<Order> GetOrderAll();
        int CreateOrder(Order orderToAdd);
        bool UpdateOrder(Order orderToUUpdate);
        bool DeleteOrder(int ID);



    }
}
