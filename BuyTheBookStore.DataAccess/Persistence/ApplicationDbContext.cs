using BuyTheBookStore.BuyTheBookStore.Core.Entities;
using BuyTheBookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuyTheBookStore.DataAccess.Persistence
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Book>().Property(u => u.NSPF).HasComputedColumnSql("\"SellCount\"/\"Price\"", stored: true);

            modelBuilder.Entity<Order>().Property<Dictionary<Guid, int>>(x =>
                x.OrderedBooks).HasConversion(
                    v => JsonSerializer.Serialize(v, new JsonSerializerOptions() { IgnoreNullValues = true }),
                    v => JsonSerializer.Deserialize<Dictionary<Guid, int>>(v, new JsonSerializerOptions() { IgnoreNullValues = true }));

            //modelBuilder.Entity<User>(e =>
            //{
            //    e.HasMany<Order>(user => user.Orders).WithOne(order => order.User).HasForeignKey(order => order.Id).OnDelete(DeleteBehavior.Cascade);
            //});
            //modelBuilder.Entity<Order>(e =>
            //{
            //    e.HasOne<User>(order => order.User).WithMany(user => user.Orders).HasForeignKey(order => order.UserId).OnDelete(DeleteBehavior.Cascade);
            //});




            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Name = "book1",
                Price = 15,
                GenreText = "action",
                AuthorName = "author1",
                SellCount = 20

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Name = "book2",
                Price = 30,
                GenreText = "action",
                AuthorName = "author2",
                SellCount = 40

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Name = "book3",
                Price = 25,
                GenreText = "action",
                AuthorName = "author3",
                SellCount = 40

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Name = "book4",
                Price = 65,
                GenreText = "action",
                AuthorName = "author4",
                SellCount = 100

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Name = "book5",
                Price = 20,
                GenreText = "romance",
                AuthorName = "author5",
                SellCount = 20

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Name = "book6",
                Price = 10,
                GenreText = "romance",
                AuthorName = "author6",
                SellCount = 40

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Name = "book7",
                Price = 35,
                GenreText = "action",
                AuthorName = "author6",
                SellCount = 50

            });


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
