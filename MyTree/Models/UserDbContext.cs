using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyTree.Models
{
	public class UserDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
		{

		}

		// Fluent API
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(p => p.FirstName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(p => p.LastName)
				.IsRequired()
				.HasMaxLength(50);


		}
	}
}
