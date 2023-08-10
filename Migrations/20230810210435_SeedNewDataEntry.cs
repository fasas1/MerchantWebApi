using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchantApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Watch", "Series 5 44mm GPS Cellular Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699385/watch-prod-3_mvvw3x.webp", "Apple Iwatch", 180000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Image" },
                values: new object[] { "Laptop", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699431/Asus_c5fdte.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691669759/iphone12_fid8e0.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Headset", "Dec Headset - Active zero noise cancelling - 20hrs battery  - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699439/headphone-prod-2_bmgfov.webp", "Dec Headset", 85000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Image", "Name", "Price" },
                values: new object[] { "Airpod", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699452/earbuds-prod-5_qmfxjx.webp", "Boat Airpod", 84000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Speaker", "Powerful and Precise. Stone 1000v2 is the premier wireless speaker that provides the best audio in the business. With its 14W stereo sound, get a boogie on and party all night.- Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699575/speaker-prod-5_tn33fk.webp", "Cod Speaker", 196000.0 });

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
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Iphone 13 - 256gb Storage - Factory Unlock - Pacific Blue Color - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699315/13_mini_ap8vpd.png", "Iphone 13", 460000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Headset", "Boom Headset - Active zero noise cancelling - 32hrs battery - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1691699650/headphone-prod-5_ayglse.webp", "Boom Headset", 125000.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Macbook", "2017 Macbook Pro - Corei5 - 16gb RAM - 512gb SSD - Touchbar - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574595/Macbook_Pro_vvbq1q.png", "Macbook Pro", 380000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Image" },
                values: new object[] { "Gaming PC", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574594/Asus_ROG_owaj4r.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574592/Iphone_13_Promax_i8mop8.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Gaming PC", "Alienware M15 R7 - 16gb RAM - 512gb SSD - 10th Generation - 6gb Nvidia RTX 2080 - RGB Backlit - Factory Unlock - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574591/Alienware_ijwzbh.png", "Alienware M15", 530000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Image", "Name", "Price" },
                values: new object[] { "Iwatch", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574593/iwatch_i9c7sp.png", "Iwatch", 240000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Gaming PC", "Pavillion 15 - 16gb RAM - 512gb SSD - 4gb Nvidia GTX 1060 - 9th Generation - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574591/HP_Pavillion_nyey1g.png", "HP Pavillion", 360000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Laptop", "HP Elitebook 1030 G2 - Corei5 - 16gb RAM - 25gbg SSD - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574591/HP_14_tohtif.png", "HP Elitebook", 250000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Iphone 14 - 512gb Storage - Factory Unlock - Pacific Blue Color - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574593/Iphone_14_bwnejg.png", "Iphone 14", 560000.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "Description", "Image", "Name", "Price" },
                values: new object[] { "Gaming PC", "Dell G7 Gaming Laptop - Corei7 - 16gb RAM - 512gb SSD - 6gb Nvidia RTX 2070 - 10th Generation - Pickup available at  No. 1 Kodeosho street, Obafemi Awolowo way Ikeja, Computer Village, Lagos State.", "https://res.cloudinary.com/dgsjzsrw4/image/upload/v1685574591/Dell_G7_r9ugk7.png", "Dell G7", 485000.0 });
        }
    }
}
