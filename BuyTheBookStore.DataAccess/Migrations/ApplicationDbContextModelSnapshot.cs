﻿// <auto-generated />
using System;
using BuyTheBookStore.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuyTheBookStore.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BuyTheBookStore.DataAccess.Persistence.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Genre")
                        .HasColumnType("integer");

                    b.Property<string>("GenreText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("NSPF")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("double precision")
                        .HasComputedColumnSql("\"SellCount\"/\"Price\"", true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("SellCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7b1a4714-bd24-4fff-ad1e-6d8c260e79da"),
                            AuthorName = "author1",
                            Genre = 0,
                            GenreText = "ACTION",
                            NSPF = 0.0,
                            Name = "book1",
                            Price = 15.0,
                            SellCount = 20
                        },
                        new
                        {
                            Id = new Guid("9d8028ce-574c-49e6-b572-5794cb157507"),
                            AuthorName = "author2",
                            Genre = 0,
                            GenreText = "ACTION",
                            NSPF = 0.0,
                            Name = "book2",
                            Price = 30.0,
                            SellCount = 40
                        },
                        new
                        {
                            Id = new Guid("c598db90-dcb7-4d71-b925-9688c0247b36"),
                            AuthorName = "author3",
                            Genre = 0,
                            GenreText = "ACTION",
                            NSPF = 0.0,
                            Name = "book3",
                            Price = 25.0,
                            SellCount = 40
                        },
                        new
                        {
                            Id = new Guid("aaaaaee4-7a3e-4bab-811b-8942554c78c6"),
                            AuthorName = "author4",
                            Genre = 0,
                            GenreText = "ACTION",
                            NSPF = 0.0,
                            Name = "book4",
                            Price = 65.0,
                            SellCount = 100
                        },
                        new
                        {
                            Id = new Guid("58c11087-dddd-43b0-9585-5e1e666336f4"),
                            AuthorName = "author5",
                            Genre = 1,
                            GenreText = "ROMANCE",
                            NSPF = 0.0,
                            Name = "book5",
                            Price = 20.0,
                            SellCount = 20
                        },
                        new
                        {
                            Id = new Guid("96d593c6-821b-446e-a2b4-be8c4e9fe179"),
                            AuthorName = "author6",
                            Genre = 1,
                            GenreText = "ROMANCE",
                            NSPF = 0.0,
                            Name = "book6",
                            Price = 10.0,
                            SellCount = 40
                        },
                        new
                        {
                            Id = new Guid("68f68905-2965-4f8f-9da4-3bf13a40eddb"),
                            AuthorName = "author6",
                            Genre = 0,
                            GenreText = "ACTION",
                            NSPF = 0.0,
                            Name = "book7",
                            Price = 35.0,
                            SellCount = 50
                        });
                });

            modelBuilder.Entity("BuyTheBookStore.DataAccess.Persistence.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("OrderedBooks")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BuyTheBookStore.DataAccess.Persistence.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("RoleText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BuyTheBookStore.DataAccess.Persistence.Models.Order", b =>
                {
                    b.HasOne("BuyTheBookStore.DataAccess.Persistence.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
