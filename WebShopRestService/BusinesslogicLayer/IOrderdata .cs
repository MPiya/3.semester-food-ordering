using WebShopModel.Model;

namespace WebShopService.BusinesslogicLayer
{
    public interface IOrderdata
    {
        Order? Get(int id);
        List<Order> Get();
        int Add(Order orderToAdd);
        bool Put(Order orderToUpdate);
        bool Delete (int id);
        
    }
}
