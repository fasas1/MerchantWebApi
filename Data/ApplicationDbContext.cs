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
                 Name = "Asus ROG",
                 Description = "Asus ROG Strix G713M - 32gb RAM - 1tb SSD - Ryzen 7 - 11th Generation - RGB Backlit - 6gb Nvidia RTX 3060 - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699431/Asus_c5fdte.jpg",
                 Price = 760000,
                 Category = "Laptop",

             }, new Product
             {
                 Id = 3,
                 Name = "Iphone 13Pro",
                 Description = "Iphoe 13Pro - 512gb Storage - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691669759/iphone12_fid8e0.png",
                 Price = 420000,
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
                 Name = "Boat Airpod",
                 Description = "Iwatch Series 7 - 44MM - GPS and Cellular - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699452/earbuds-prod-5_qmfxjx.webp",
                 Price = 84000,
                 Category = "Airpod",

             }, new Product
             {
                 Id = 6,
                 Name = "Cod Speaker",
                 Description = "Powerful and Precise. Stone 1000v2 is the premier wireless speaker that provides the best audio in the business. With its 14W stereo sound, get a boogie on and party all night.- Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699575/speaker-prod-5_tn33fk.webp",
                 Price = 196000,
                 Category = "Speaker",

             }, new Product
             {
                 Id = 7,
                 Name = "Iphone 14 Promax",
                 Description = "Iphoe 14 Promax - 512gb Storage - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699516/iphone_14_purple_ck04dl.png",
                 Price = 750000,
                 Category = "Iphone",

             }, new Product
             {
                 Id = 8,
                 Name = "Iphone 13",
                 Description = "Iphone 13 - 256gb Storage - Factory Unlock - Pacific Blue Color - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.",
                 Image = "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699315/13_mini_ap8vpd.png",
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
