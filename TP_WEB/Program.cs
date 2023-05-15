using Microsoft.EntityFrameworkCore;
using TP_WEB.Configurations;
using TP_WEB.Models;
using Microsoft.AspNetCore.Identity;
using TP_WEB.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SiteContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<TP_WEBIdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TP_WEBIdentityDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PeutAfficherEdit", policy => policy.RequireRole("Administrateur"));
});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TP_WEBIdentityDbContext>();

builder.Services.Configure<SMTPConfig>(builder.Configuration.GetSection("MesConfigs").GetSection("SMTP"));

var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{ 
    var dbContext = scope.ServiceProvider.GetRequiredService<SiteContext>();
    dbContext.Database.Migrate();

    var dbIdentity = scope.ServiceProvider.GetRequiredService<TP_WEBIdentityDbContext>();
    dbIdentity.Database.Migrate();

    IdentityManager.CreateRoles(scope.ServiceProvider).Wait();
}

DBInitializer.CreateDataIfNotExists(app);

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

