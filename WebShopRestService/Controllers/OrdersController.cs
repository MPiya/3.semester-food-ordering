using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestAPI.Dtos;
using WebShopModel.Model;
using WebShopService.BusinesslogicLayer;
using WebShopService.Dtos;
using RestAPI.ModelConversion;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderdataControl _oControl;
        private readonly IConfiguration _configuration;

        public OrdersController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _oControl = new OrderdataControl(_configuration);
        }
        // URL: api/orders
        [HttpGet]
        public ActionResult<List<OrderDto>> Get()
        {
            ActionResult<List<OrderDto>> foundReturn;
            // retrieve and convert data
            List<Order>? foundOrders = _oControl.Get();
            List<OrderDto>? foundDts = null;
            if (foundOrders != null)
            {
                foundDts = ModelConversion.OrderDtoConvert.FromOrderCollection(foundOrders);
            }
            // evaluate
            if (foundDts != null)
            {
                if (foundDts.Count > 0)
                {
                    foundReturn = Ok(foundDts); // Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204); // Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500); // Internal server error
            }
            // send response back to client
            return foundReturn;

        }

        // URL: api/orders/Detail
        [HttpGet, Route("{Detail}")]
        public ActionResult<List<OrderDto>> GetOrderDetail()
        {
            ActionResult<List<OrderDto>> foundReturn;
            // retrieve and convert data
            List<Order>? foundOrders = _oControl.GetOrderCustomer();
            List<OrderDto>? foundDts = null;
            if (foundOrders != null)
            {
                foundDts = OrderDtoConvert.FromJoinOrderCollection(foundOrders);
            }
            // evaluate
            if (foundDts != null)
            {
                if (foundDts.Count > 0)
                {
                    foundReturn = Ok(foundDts); // Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204); // Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500); // Internal server error
            }
            // send response back to client
            return foundReturn;

        }



        /*
        // URL: api/orders/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<OrderDto> Get(int id)
        {
            return null;
        }*/

        // URL: api/orders
        [HttpPost]
        public ActionResult<int> PostNewOrder(OrderDto inOrder)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;

            if (inOrder != null)
            {
                Order? dbOrder = OrderDtoConvert.ToOrder(inOrder);
                insertedId = _oControl.Add(dbOrder);

            }
            if (insertedId > 0)
            {
                foundReturn = Ok(insertedId);

            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

    }
}
