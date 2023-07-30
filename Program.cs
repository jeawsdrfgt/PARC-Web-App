global using PARC_Web_App.Models;
global using PARC_Web_App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PARC_Web_App.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PARC_Web_AppContextConnection") ?? throw new InvalidOperationException("Connection string 'PARC_Web_AppContextConnection' not found.");

builder.Services.AddDbContext<PARC_Web_AppContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PARC_Web_App.Areas.Identity.Data.PARC_Web_AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PARC_Web_AppContext>();

builder.Services.AddScoped<IEmailService, EmailService>();

// Add services to the container.
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
