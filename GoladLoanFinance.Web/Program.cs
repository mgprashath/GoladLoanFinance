using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Application.Services;
using GoldLoanFinance.Infrastructure.Data;
using GoldLoanFinance.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<BankServices>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<LoanService>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<RepledgeService>();
builder.Services.AddScoped<IRepledgeRepository, RepledgeRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
