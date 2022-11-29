
using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Repository.IRepository;
using WebShopModel.Model;

namespace WebShop.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
      //  void Update(Product product);
    }
}
