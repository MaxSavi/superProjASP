using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using superProjASP.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<superProjASPContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("superProjASPContext") ?? throw new InvalidOperationException("Connection string 'superProjASPContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddControllers(); // Добавление сервисов для контроллеров API          
//builder.Services.AddDbContext<superProjASPContext>(options =>
// options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

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

app.MapControllers(); // Добавление маршрутов для контроллеров API

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
