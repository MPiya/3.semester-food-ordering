
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Models;
using WebShop.Repository.IRepository;
using WebShopWebServerAPIClient1.Data;

namespace Webshop.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly AppDbContext _db;

        public ShoppingCartRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ShoppingCart obj)
        {
            _db.Update(obj);
        }


    }
}
