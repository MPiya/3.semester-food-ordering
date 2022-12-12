using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using WebShopModel.Model;

namespace WebShop.Models
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