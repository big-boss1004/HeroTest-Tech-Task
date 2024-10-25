using System.Text.Json.Serialization;
using HeroTest.Configurations;
using HeroTest.Contracts;
using HeroTest.Models;
using HeroTest.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SampleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ObjectDB"));

});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        // options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

var app = builder.Build();


app.UseCors(options =>
  options.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
   name: "default",
   pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
