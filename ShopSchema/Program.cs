using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopSchema.Data;
using WebApplication1.DB.Connections;
using WebApplication1.HelperServices;
using WebApplication1.Services.Implimentations;
using WebApplication1.Services.Models;



var builder = WebApplication.CreateBuilder(args);

#region Add custom services

builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IGhostUser, GhostUser>();
builder.Services.AddSingleton<DBConnection>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();