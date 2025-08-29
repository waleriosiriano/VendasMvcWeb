using Microsoft.EntityFrameworkCore;
using VendasMvcWeb.Data;
using VendasMvcWeb.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;


var builder = WebApplication.CreateBuilder(args);

//  Troca para MySQL com Pomelo
builder.Services.AddDbContext<VendasMvcWebContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("VendasMvcWebContext")
        ?? throw new InvalidOperationException("Connection string 'VendasMvcWebContext' not found."),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("VendasMvcWebContext"))
    ));

//  REGISTRA o serviço de seeding
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};
app.UseRequestLocalization(localizationOptions);


// O SEED acontece aqui durante o ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    //  resolve o serviço e executa a seed
    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
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

app.Run();

