using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;
using WebShopModel.Model;

namespace WebShopWebServerAPIClient1.Data
{
	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{


		}	

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Order { get;}
		
		public DbSet<OrderLine> OrderLine { get; set; }

		public DbSet<Product> Product { get; set; }

	
	}
}