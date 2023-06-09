using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using dotenv.net;
using MerchantApi.Data;
using MerchantApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


// Set your Cloudinary credentials
//=================================

DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
cloudinary.Api.Secure = true;


// Upload an image and log the response to the console
//=================

var uploadParams = new ImageUploadParams()
{
    File = new FileDescription(@"https://res.cloudinary.com/demo/image/upload/c_scale,w_300/e_cartoonify/cld-sample"),
    UseFilename = true,
    UniqueFilename = false,
    Overwrite = true
};
var uploadResult = cloudinary.Upload(uploadParams);
Console.WriteLine(uploadResult.JsonObj);


// Transform the uploaded asset and generate a URL and image tag
//==============================

var myTransformation = cloudinary.Api.UrlImgUp.Transform(new Transformation()
    .Width(300).Crop("scale").Chain()
    .Effect("cartoonify"));

var myUrl = myTransformation.BuildUrl("cld-sample");
var myImageTag = myTransformation.BuildImageTag("cld-sample");

// Log the URL of the transformed asset to the console
Console.WriteLine(myUrl);

// Log the image tag for the transformed asset to the console
Console.WriteLine(myImageTag);
//////////////
///


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
