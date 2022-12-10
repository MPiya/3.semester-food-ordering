using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopModel.Model;

namespace WebShopData.DatabaseLayer
{
    public interface IOrderLineAccess
    {
        int CreateOrderLine(OrderLine orderLineToAdd);
        OrderLine GetOrderLineByProductID(int productID);
        List<OrderLine> GetOrderLineAll();

        bool UpdateOrderLine(OrderLine OrderLineToUpdate);
        

    }
}

