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
    public class OrderLinesController : ControllerBase
    {
        private readonly OrderLinedataControl _oControl;
        private readonly IConfiguration _configuration;

        public OrderLinesController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _oControl = new OrderLinedataControl(_configuration);
        }
        // URL: api/orders
        [HttpGet]
        
        [HttpPost]
        public ActionResult<int> PostNewOrderLine(OrderLineDto inOrderLine)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;

            if (inOrderLine != null)
            {
                OrderLine? dbOrder = OrderLineDtoConvert.ToOrderLine(inOrderLine);
                insertedId = _oControl.Create(dbOrder);

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
