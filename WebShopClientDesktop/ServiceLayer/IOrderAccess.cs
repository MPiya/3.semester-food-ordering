using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopClientDesktop.ModelLayer;

namespace WebShopClientDesktop.ServiceLayer
{
    public interface IOrderAccess
    {

        Task<List<Order>?>? GetOrders(int id = -1);
        Task<int> SaveOrder(Order orderToSave);

    }
}
