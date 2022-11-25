using Microsoft.AspNetCore.Mvc;
using WebShopModel.Model;
using WebShopService.BusinesslogicLayer;
using WebShopService.Dtos;

namespace WebShopService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerdataControl _cControl;
        private readonly IConfiguration _configuration;
        public CustomersController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _cControl = new CustomerdataControl(_configuration);
        }


        // URL: api/Customers
        [HttpGet]
        public ActionResult<List<CustomerDto>> Get()
        {
            ActionResult<List<CustomerDto>> foundReturn;
            // retrieve and convert data 
            List<Customer>? foundCustomers = _cControl.Get();
            List<CustomerDto>? foundDts = null;
            if (foundCustomers != null)
            {
                foundDts = ModelConversion.CustomerDtoConvert.FromCustomerCollection(foundCustomers);
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
        // URL: api/customer/{id} 
        [HttpGet, Route("{id}")]
        public ActionResult<CustomerDto> Get(int id)
        {
            return null;

        }
        */
        // URL: api/customers
        //        [HttpPost]
        // public ActionResult<int> PostNewCustomer(CustomerDto inCustomer)
        //{
        //  ActionResult<int> foundReturn;
        //int insertedId = -1;
        //if (inCustomer != null)
        //{
        //  Customer? dbCustomer = ModelConversion.CustomerDtoConvert.ToCustomer(inCustomer);
        //insertedId = _cControl.Add(dbCustomer);
        //}
        //if (insertedId > 0)
        //{
        //  foundReturn = Ok(insertedId);
        //}
        //else
        //{
        //  foundReturn = new StatusCodeResult(500); // Internal server error
        //}
        //return foundReturn;

        //}
    }
}
