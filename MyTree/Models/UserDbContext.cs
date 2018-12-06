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
		public DbSet<Person> People { get; set; }
		public DbSet<FamilyMember> FamilyMembers { get; set; }
		public DbSet<Address> Address { get; set; }

		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
		{
			
		}

		// Fluent API
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(p => p.Username)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(p => p.Password)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(p => p.FirstName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(p => p.LastName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(p => p.Email)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(p => p.PhoneNumber)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<User>()
				.Property(p => p.UserRole)
				.IsRequired()
				.HasConversion<string>();


			modelBuilder.Entity<Address>()
				.HasAlternateKey(a => new { a.Street, a.ZipCode, a.Country });

			modelBuilder.Entity<Address>()
				.Property(a => a.City)
				.IsRequired()
				.HasMaxLength(100);

			modelBuilder.Entity<Address>()
				.Property(a => a.ZipCode)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Address>()
				.Property(a => a.Street)
				.IsRequired()
				.HasMaxLength(200);

			
			modelBuilder.Entity<Person>()
				.Property(p => p.FirstName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Person>()
				.Property(p => p.LastName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Person>()
				.Property(p => p.Birthday)
				.IsRequired()
				.HasColumnType("DateTime2");

		}
	}
}
