
using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Repository.IRepository;
using WebShop.Models;
using WebShopModel.Model;

namespace WebShop.Repository.IRepository
{

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    void Update(ShoppingCart obj);


}

}