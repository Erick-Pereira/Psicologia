using BusinessLogicalLayer.BLL;
using BusinessLogicalLayer.Interfaces;
using DataAcessLayer;
using DataAcessLayer.Impl;
using DataAcessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IFuncionarioService, FuncionarioService>();
builder.Services.AddTransient<IFuncionarioDAL, FuncionarioDAL>();
builder.Services.AddTransient<IEquipeService, EquipeService>();
builder.Services.AddTransient<IEquipeDAL, EquipeDAL>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<DataBaseDbContext>(options => options.UseSqlServer("name=ConnectionStrings:SqlServerFuncionarioConnection"));

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