using ECommerceApi.Domain.Entities;
using ECommerceApi.Persistence.Entity_Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Detail> Order_Details { get; set; }
        public DbSet<Product_Comment> Product_Comments { get; set; }
        public DbSet<Product_Rating> Product_Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.ApplyConfiguration(new AppUserConfig());
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new OrderConfig());
            builder.ApplyConfiguration(new ProductCommentConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new ProductRatingConfig());
            builder.ApplyConfiguration(new OrderDetailConfig());
            builder.ApplyConfiguration(new AddressConfig());
            builder.ApplyConfiguration(new BasketConfig());
            builder.ApplyConfiguration(new BasketItemConfig());



            base.OnModelCreating(builder);
        }



    }
}
