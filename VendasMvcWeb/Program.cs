using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendasMvcWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Troca para MySQL com Pomelo
builder.Services.AddDbContext<VendasMvcWebContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("VendasMvcWebContext")
        ?? throw new InvalidOperationException("Connection string 'VendasMvcWebContext' not found."),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("VendasMvcWebContext"))
    ));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
