
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webshop.Repository;
using WebShop.Repository.IRepository;
using WebShopModel.Model;
using WebShopWebServerAPIClient1.Data;

namespace Webshop.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Product product)
        { // Find the product  by using product.ID
           var objFromDb = _db.Product.FirstOrDefault(s => s.ID == product.ID);
            if (objFromDb != null)
            {
               
            
                objFromDb.Price = product.Price;
               
                
            }
        }
    }
}
