using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchantApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Iphone", "Iphone 14 Promax Midnight Purple - 512gb Storage - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699516/iphone_14_purple_ck04dl.png", "Iphone 14 Promax", 750000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Iphone 13 Pro - 512gb Storage - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "Iphone 13 Pro", 540000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Oraimo Riff Smaller For Comfort TWS True Wireless Earbuds - 4 COLORS - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691871784/earbuds-prod-4_la7u7j.webp", "Oraimo Airpod", 34000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Iphone 13 Pro 256gb - Starlight Blue - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691871777/13pro_blue_ws4pjl.png", "Iphone 13 Pro", 496000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Watch", "Samsung Galaxy Watch 5 Classic 46mm, Bluetooth Smartwatch - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691871415/watch-prod-2_eya0ym.webp", "Samsung Watch 5", 250000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Iphone 13 Promax - 256gb Storage - Factory Unlock - Pacific Gold Color - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691871765/13_pro_gold_gzh0ao.png", "Iphone 13 Promax" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Laptop", "Asus ROG Strix G713M - 32gb RAM - 1tb SSD - Ryzen 7 - 11th Generation - RGB Backlit - 6gb Nvidia RTX 3060 - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699431/Asus_c5fdte.jpg", "Asus ROG", 760000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Iphoe 13Pro - 512gb Storage - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "Iphone 13Pro", 420000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Iwatch Series 7 - 44MM - GPS and Cellular - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699452/earbuds-prod-5_qmfxjx.webp", "Boat Airpod", 84000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Powerful and Precise. Stone 1000v2 is the premier wireless speaker that provides the best audio in the business. With its 14W stereo sound, get a boogie on and party all night.- Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699575/speaker-prod-5_tn33fk.webp", "Cod Speaker", 196000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Iphone", "Iphoe 14 Promax - 512gb Storage - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699516/iphone_14_purple_ck04dl.png", "Iphone 14 Promax", 750000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Iphone 13 - 256gb Storage - Factory Unlock - Pacific Blue Color - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699315/13_mini_ap8vpd.png", "Iphone 13" });
        }
    }
}
