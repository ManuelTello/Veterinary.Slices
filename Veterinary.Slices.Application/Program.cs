using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Veterinary.Slices.Application.Data;

var builder = WebApplication.CreateBuilder(args);
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection");
var veterinaryConnectionString = builder.Configuration.GetConnectionString("VeterinaryConnection");

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(identityConnectionString);
});
builder.Services.AddDbContext<VeterinaryContext>(options =>
{ 
    options.UseSqlServer(veterinaryConnectionString);
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<IdentityContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

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
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
