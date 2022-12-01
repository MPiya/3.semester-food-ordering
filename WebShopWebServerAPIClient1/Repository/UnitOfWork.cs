﻿
using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Repository;
using WebShop.Repository.IRepository;
using WebShopWebServerAPIClient1.Data;

namespace WebShop.Repository
{
    public class UnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            /*
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Company = new CompanyRepository(_db);
            Product = new ProductRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            SP_Call = new SP_Call(_db);
            OrderDetails = new OrderDetailsRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);*/
            ShoppingCart = new ShoppingCartRepository(_db);
            Product = new ProductRepository(_db);

        }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IProductRepository Product { get; private set; }
        /*
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
     
        public IOrderDetailsRepository OrderDetails { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public ISP_Call SP_Call { get; private set; }*/

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}