using WebShopModel.Model;

namespace RESTAPI.BusinesslogicLayer
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
