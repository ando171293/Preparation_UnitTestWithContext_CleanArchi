using Microsoft.EntityFrameworkCore;
using Preparation.IRepos;
using Preparation.IService;
using Preparation.Models;
using Preparation.Repos;
using Preparation.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddScoped<IReposParents, ReposParents>();
builder.Services.AddScoped<IServiceParents, ServiceParents>();
builder.Services.AddScoped<IReposPersonnes, ReposPersonnes>();
builder.Services.AddScoped<IServicePersonnes, ServicePersonnes>();


var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");
builder.Services.AddDbContext<PreparationContext>(x => x.UseSqlServer(connectionString));





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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
