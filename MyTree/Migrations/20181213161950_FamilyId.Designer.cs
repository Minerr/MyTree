﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyTree.Models;

namespace MyTree.Migrations
{
    [DbContext(typeof(MyTreeDbContext))]
    [Migration("20181213161950_FamilyId")]
    partial class FamilyId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyTree.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("ZipCode")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasAlternateKey("Street", "ZipCode", "Country");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("MyTree.Models.FamilyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FamilyId");

                    b.Property<int?>("ParentOneId");

                    b.Property<int?>("ParentTwoId");

                    b.Property<int?>("PartnerId");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("ParentOneId");

                    b.HasIndex("ParentTwoId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("PersonId");

                    b.ToTable("FamilyMembers");
                });

            modelBuilder.Entity("MyTree.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("DateTime2");

                    b.Property<int>("FamilyId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MyTree.Models.FamilyMember", b =>
                {
                    b.HasOne("MyTree.Models.Person", "ParentOne")
                        .WithMany()
                        .HasForeignKey("ParentOneId");

                    b.HasOne("MyTree.Models.Person", "ParentTwo")
                        .WithMany()
                        .HasForeignKey("ParentTwoId");

                    b.HasOne("MyTree.Models.Person", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId");

                    b.HasOne("MyTree.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("MyTree.Models.Person", b =>
                {
                    b.HasOne("MyTree.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });
#pragma warning restore 612, 618
        }
    }
}
