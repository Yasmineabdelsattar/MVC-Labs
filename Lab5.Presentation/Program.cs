using Lab5.BL.Managers.Departments;
using Lab5.BL.Managers.Developers;
using Lab5.BL.Managers.Tickets;
using Lab5.DAL.Context;
using Lab5.DAL.Repos.DepartmentsRepo;
using Lab5.DAL.Repos.DevelopersRepo;
using Lab5.DAL.Repos.TicketsRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Database context

var connectionString = builder.Configuration.GetConnectionString("HospitalSystem");
builder.Services.AddDbContext<TicketContext>(options
    => options.UseSqlServer(connectionString));

#endregion

#region Managers

builder.Services.AddScoped<ITicketsManager, TicketsManager>();
builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();
builder.Services.AddScoped<IDevelopersManager, DevelopersManager>();

#endregion

#region Repos

builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();
builder.Services.AddScoped<IDevelopersRepo, DevelopersRepo>();

#endregion


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
