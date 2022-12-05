using WebShopModel.Model;

namespace WebShopService.BusinesslogicLayer
{
    public interface ICustomerdata
    {
        Customer? Get(int id);
        List<Customer>? Get();
        bool Add(Customer customerToAdd);
        
        bool Put(Customer customerToUpdate);
        bool Delete(int id);
    }
}