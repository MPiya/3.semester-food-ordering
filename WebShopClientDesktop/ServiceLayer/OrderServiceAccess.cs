using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopClientDesktop.ModelLayer;

namespace WebShopClientDesktop.ServiceLayer
{
    public class OrderServiceAccess : IOrderAccess
    {

        readonly IServiceConnection _orderService;
        readonly String _serviceBaseUrl = "https://localhost:7177/api/orders";

        public OrderServiceAccess()
        {
            _orderService = new ServiceConnection(_serviceBaseUrl);


        }
        // method to retrieve Order(s)
      

        public async Task<List<Order>?>? GetOrders(int id = -1)
        {
            List<Order>? ordersFromService = null;

            _orderService.UseUrl = _orderService.BaseUrl;
            bool hasValidId = (id > 0);
            if (hasValidId)
            {
                _orderService.UseUrl += id.ToString();
            }
            if (_orderService != null)
            {
                try
                {
                    var serviceResponse = await _orderService.CallServiceGet();
                    bool wasResponse = (serviceResponse != null);
                    if (wasResponse && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();
                        if (hasValidId)
                        {
                            Order? foundOrder = JsonConvert.DeserializeObject<Order>(content);
                            if (foundOrder != null)
                            {
                                ordersFromService = new List<Order>() { foundOrder };
                            }
                        }
                        else
                        {
                            ordersFromService = JsonConvert.DeserializeObject<List<Order>>(content);
                        }
                    }
                    else
                    {
                        if (wasResponse && serviceResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            ordersFromService = new List<Order>();
                        }
                        else
                        {
                            ordersFromService = null;
                        }
                    }
                }
                catch
                {
                    ordersFromService = null;
                }
            }
            return ordersFromService;
        }

        public async Task<int> SaveOrder(Order orderToSave)
        {
            int insertedOrderId = -1;

            _orderService.UseUrl = _orderService.BaseUrl;
            try
            {
                var json = JsonConvert.SerializeObject(orderToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var serviceResponse = await _orderService.CallServicePost(content);
                bool wasResponse = (serviceResponse != null);
                if (wasResponse && serviceResponse.IsSuccessStatusCode)
                {
                    if (serviceResponse.IsSuccessStatusCode)
                    {
                        string resIdString = await serviceResponse.Content.ReadAsStringAsync();
                        Int32.TryParse(resIdString, out insertedOrderId);
                    }
                    else
                    {
                        insertedOrderId = -2;
                    }
                }
            }
            catch
            {
                insertedOrderId = -3;
            }
            return insertedOrderId;
        }

      
    }
}
