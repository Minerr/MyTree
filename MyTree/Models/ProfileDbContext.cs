using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyTree.Models
{
	public class ProfileDbContext : DbContext
	{
		public DbSet<Person> Profiles { get; set; }

		public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>()
				.Property(p => p.FirstName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Person>()
				.Property(p => p.LastName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Person>()
				.Ignore(p => p.FullName);


		}
	}
}
