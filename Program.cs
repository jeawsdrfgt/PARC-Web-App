using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PARC_Web_App.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PARC_Web_AppContextConnection") ?? throw new InvalidOperationException("Connection string 'PARC_Web_AppContextConnection' not found.");

builder.Services.AddDbContext<PARC_Web_AppContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PARC_Web_App.Areas.Identity.Data.PARC_Web_AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<PARC_Web_AppContext>();

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
