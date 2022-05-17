using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Magacin.Data;
using MudBlazor.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Magacin.Areas.Identity.Data;
using Magacin.Services;
using Magacin.ViewModels;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DBConnection") ?? throw new InvalidOperationException("Connection string 'DBConnection' not found.");

builder.Services.AddDbContext<DB>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Magacioner>()
    .AddEntityFrameworkStores<DB>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserVM, UserVM>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;

app.Run();