using WebShopModel.Model;

namespace WebShopData.DatabaseLayer
{
    public interface ICustomerAccess
    {
        Customer? GetCustomerById(int id);
        List<Customer>? GetCustomerAll();
        int CreateCustomer(Customer CustomerToAdd);
        bool UpdateCustomer(Customer CustmerToUpdate);
        bool DeleteCustomerById(int id);
    }
}