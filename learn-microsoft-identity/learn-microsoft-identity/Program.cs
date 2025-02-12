using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using learn_microsoft_identity.Data;
using learn_microsoft_identity.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("learn_microsoft_identityContextConnection") ?? throw new InvalidOperationException("Connection string 'learn_microsoft_identityContextConnection' not found.");;

builder.Services.AddDbContext<learn_microsoft_identityContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>
    (options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<learn_microsoft_identityContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapRazorPages();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
