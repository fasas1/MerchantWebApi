using MerchantApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace MerchantApi.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions option) :base(option)
        {     
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 Id = 1,
                 Name = "Apple Iwatch",
                 Description = "Series 5 44mm GPS Cellular Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699385/watch-prod-3_mvvw3x.webp",
                 Price = 180000,
                 Category = "Watch",

             }, new Product
             {
                 Id = 2,
                 Name = "Iphone 14 Promax",
                 Description = "Iphone 14 Promax Midnight Purple - 512gb Storage - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699516/iphone_14_purple_ck04dl.png",
                 Price = 750000,
                 Category = "Iphone",

             }, new Product
             {
                 Id = 3,
                 Name = "Iphone 13 Pro",
                 Description = "Iphone 13 Pro - 512gb Storage - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691669759/iphone12_fid8e0.png",
                 Price = 540000,
                 Category = "Iphone",

             }, new Product
             {
                 Id = 4,
                 Name = "Dec Headset",
                 Description = "Dec Headset - Active zero noise cancelling - 20hrs battery  - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699439/headphone-prod-2_bmgfov.webp",
                 Price = 85000,
                 Category = "Headset",

             }, new Product
             {
                 Id = 5,
                 Name = "Oraimo Airpod",
                 Description = "Oraimo Riff Smaller For Comfort TWS True Wireless Earbuds - 4 COLORS - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691871784/earbuds-prod-4_la7u7j.webp",
                 Price = 34000,
                 Category = "Airpod",

             }, new Product
             {
                 Id = 6,
                 Name = "Iphone 13 Pro",
                 Description = "Iphone 13 Pro 256gb - Starlight Blue - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691871777/13pro_blue_ws4pjl.png",
                 Price = 496000,
                 Category = "Speaker",

             }, new Product
             {
                 Id = 7,
                 Name = "Samsung Watch 5",
                 Description = "Samsung Galaxy Watch 5 Classic 46mm, Bluetooth Smartwatch - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691871415/watch-prod-2_eya0ym.webp",
                 Price = 250000,
                 Category = "Watch",

             }, new Product
             {
                 Id = 8,
                 Name = "Iphone 13 Promax",
                 Description = "Iphone 13 Promax - 256gb Storage - Factory Unlock - Pacific Gold Color - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691871765/13_pro_gold_gzh0ao.png",
                 Price = 460000,
                 Category = "Iphone",

             }, new Product
             {
                 Id = 9,
                 Name = "Boom Headset",
                 Description = "Boom Headset - Active zero noise cancelling - 32hrs battery - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699650/headphone-prod-5_ayglse.webp",
                 Price = 125000,
                 Category = "Headset",

             }, new Product
             {
                 Id = 10,
                 Name = "Macbook Pro",
                 Description = "2019 Macbook Pro - 16gb RAM - 512gb SSD - Touchbar - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574593/Mabook_Pro_aicpdz.png",
                 Price = 455000,
                 Category = "Macbook",
             }

             );

        }
    }
}
