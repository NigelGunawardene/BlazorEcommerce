global using BlazorEcommerce.Shared;
using BlazorEcommerce.DataAccess.Seed;
using BlazorEcommerce.Infrastructure.Data;
using BlazorEcommerce.Server.Interfaces;
using BlazorEcommerce.Server.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Development")); //, x => x.MigrationsAssembly("BlazorEcommerce.Infrastructure.Migrations")
});



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAppConfigService, AppConfigService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ContextSeeder>();

var app = builder.Build();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();


// call custom methods here
//EnsureNewDatabase();
SeedDatabase();
//end call custom methods


app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


async void SeedDatabase() //can be placed at the very bottom under app.Run()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<ContextSeeder>();
        await dbInitializer.SeedAsync();
    }
}


//async void EnsureNewDatabase()
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
//        await dbContext.Database.EnsureDeletedAsync();
//        await dbContext.Database.EnsureCreatedAsync();
//        //dbContext.Database.Migrate(); // this method is an alternative to ensuredeleted/created. those do not work well with migrations
//    }
//}