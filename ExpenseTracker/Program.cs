using ExpenseTracker.DB;
//using ExpenseTracker.infrastracture;
//using ExpenseTracker.infrastracture.Interface;
//using ExpenseTracker.infrastracture.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ETContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExpenseConnectionString")));

//builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

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
