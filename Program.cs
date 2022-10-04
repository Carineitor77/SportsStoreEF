using Chapter4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
/*builder.Services.AddMvc().AddJsonOptions(opts =>
{
    opts.SerializerSettings.ReferenceLoopHandling
        = ReferenceLoopHandling.Serialize;
});*/

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddTransient<IRepository, DataRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();
builder.Services.AddTransient<IWebServiceRepository, WebServiceRepository>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.Cookie.Name = "SportsStore.Session";
    options.IdleTimeout = System.TimeSpan.FromHours(48);
    options.Cookie.HttpOnly = false;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.MapDefaultControllerRoute();

app.Run();