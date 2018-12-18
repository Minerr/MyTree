using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyTree.Models
{
	public class MyTreeDbContext : DbContext
	{
		public DbSet<Person> People { get; set; }
		//public DbSet<Pair> Pairs { get; set; }
		public DbSet<Family> Families { get; set; }

		public MyTreeDbContext(DbContextOptions<MyTreeDbContext> options) : base(options)
		{
			
		}

		// Fluent API
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Address>()
			//	.HasAlternateKey(a => new { a.Street, a.ZipCode, a.Country });

			//modelBuilder.Entity<Address>()
			//	.Property(a => a.City)
			//	.IsRequired()
			//	.HasMaxLength(100);

			//modelBuilder.Entity<Address>()
			//	.Property(a => a.ZipCode)
			//	.IsRequired()
			//	.HasMaxLength(50);

			//modelBuilder.Entity<Address>()
			//	.Property(a => a.Street)
			//	.IsRequired()
			//	.HasMaxLength(200);


			modelBuilder.Entity<Family>()
				.HasMany(f => f.People)
				.WithOne(p => p.Family)
				.IsRequired();


			modelBuilder.Entity<Person>()
				.Property(p => p.Gender)
				.IsRequired()
				.HasConversion<string>();

			modelBuilder.Entity<Person>()
				.Property(p => p.FirstName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Person>()
				.Property(p => p.LastName)
				.IsRequired()
				.HasMaxLength(50);


			modelBuilder.Entity<Pair>()
				.Property(p => p.IsTogether)
				.IsRequired();

			modelBuilder.Entity<Pair>()
				.HasMany(p => p.Children)
				.WithOne()
				.HasForeignKey("FK_ParentPair")
				.IsRequired(false);

			modelBuilder.Entity<Pair>()
				.HasMany(p => p.AdoptedChildren)
				.WithOne()
				.HasForeignKey("FK_AdoptedPair")
				.IsRequired(false);


			modelBuilder.Entity<PersonPair>()
				.HasKey(pp => new { pp.PersonId, pp.PairId });

			modelBuilder.Entity<PersonPair>()
				.HasOne(pp => pp.Person)
				.WithMany(p => p.Relationships)
				.HasForeignKey(pp => pp.PersonId)
				.IsRequired();

			modelBuilder.Entity<PersonPair>()
				.HasOne(pp => pp.Pair)
				.WithMany(p => p.Partners)
				.HasForeignKey(pp => pp.PairId)
				.IsRequired();
		}
	}
}
