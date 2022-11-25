using WebShopData.DatabaseLayer;
using WebShopModel.Model;

namespace WebShopService.BusinesslogicLayer
{
    public class CustomerdataControl : ICustomerdata
    {
        ICustomerAccess _customerAccess;
        public CustomerdataControl(IConfiguration inConfiguration)
        {
            _customerAccess = new CustomerDatabaseAccess(inConfiguration);
        }
        public int Add(Customer newCustomer)
        {
            int insertedId;
            try
            {
                insertedId = _customerAccess.CreateCustomer(newCustomer);
            }
            catch
            {
                insertedId = -1;
            }

            return insertedId;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer? Get(int idToMatch)
        {
            Customer? foundCustomer;
            try
            {
                foundCustomer = _customerAccess.GetCustomerById(idToMatch);
            }
            catch
            {
                foundCustomer = null;
            }
            return foundCustomer;
        }

        public List<Customer>? Get()
        {
            List<Customer>? foundCustomers;
            try
            {
                foundCustomers = _customerAccess.GetCustomerAll();
            }
            catch
            {
                foundCustomers = null;
            }
            return foundCustomers;
        }

        public bool Put(Customer customerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}