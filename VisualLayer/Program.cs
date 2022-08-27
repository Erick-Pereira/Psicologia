using BusinessLogicalLayer.BLL;
using BusinessLogicalLayer.Interfaces;
using DataAcessLayer;
using DataAcessLayer.Impl;
using DataAcessLayer.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Home/Index");
        options.AccessDeniedPath = new PathString("/Home/Index");
    });
builder.Services.AddTransient<IBairroDAL, BairroDAL>();
builder.Services.AddTransient<IBairroService, BairroService>();
builder.Services.AddTransient<ICargoDAL, CargoDAL>();
builder.Services.AddTransient<ICargoService, CargoService>();
builder.Services.AddTransient<ICidadeDAL, CidadeDAL>();
builder.Services.AddTransient<ICidadeService, CidadeService>();
builder.Services.AddTransient<ICompromissoDAL, CompromissoDAL>();
builder.Services.AddTransient<IEnderecoDAL, EnderecoDAL>();
builder.Services.AddTransient<IEnderecoService, EnderecoService>();
builder.Services.AddTransient<IEquipeDAL, EquipeDAL>();
builder.Services.AddTransient<IEquipeService, EquipeService>();
builder.Services.AddTransient<IEstadoDAL, EstadoDAL>();
builder.Services.AddTransient<IEstadoService, EstadoService>();
builder.Services.AddTransient<IFuncionarioDAL, FuncionarioDAL>();
builder.Services.AddTransient<IFuncionarioService, FuncionarioService>();
builder.Services.AddTransient<IInicioService, InicioService>();

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

app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Strict, HttpOnly = HttpOnlyPolicy.Always });

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();