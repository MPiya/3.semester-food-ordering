using Microsoft.AspNetCore.Mvc;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;

namespace WebShopService.BusinesslogicLayer
{
    public class ProductdataControl : IProductdata
    {
        IProductAccess _productAccess;
        
        public ProductdataControl(IConfiguration inConfiguration)
        {
            _productAccess = new ProductDatabaseAccess(inConfiguration);
        }
        
        public List<Product> Get()
        {
            List<Product>? foundProducts;
            try
            {
                foundProducts = _productAccess.GetProductAll();
            }
            catch
            {
                foundProducts = null;
            }
            return foundProducts;
        }

    }
}
