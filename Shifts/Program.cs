using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shifts.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(300);
    options.Cookie.HttpOnly = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});
builder.Services.AddDbContext<ShiftsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShiftsContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");


app.Run();
