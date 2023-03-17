using Lab5.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab5.DAL.Context;

public class TicketContext: DbContext
{
    public DbSet<Department> Doctors => Set<Department>();
    public DbSet<Ticket> Patients => Set<Ticket>();
    public DbSet<Developer> Issues => Set<Developer>();

    public TicketContext(DbContextOptions<TicketContext> options)
        : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Seeding Dept
        var tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Id":1,"Description":"good","DepartmentId":1},{"Id":2,"Description":"bad","DepartmentId":2},{"Id":3,"Description":"mideum","DepartmentId":1},{"Id":4,"Description":"amazing","DepartmentId":3},{"Id":5,"Description":"wow","DepartmentId":4}]""") ?? new();
        var departments = JsonSerializer.Deserialize<List<Department>>("""[{"Id":1,"Name":"Diabetes"},{"Id":2,"Name":"Hypertension"},{"Id":3,"Name":"Asthma"},{"Id":4,"Name":"Depression"},{"Id":5,"Name":"Arthritis"}]""") ?? new();
        var developers = JsonSerializer.Deserialize<List<Developer>>("""[{"Id":1,"Name":"john"},{"Id":2,"Name":"isaac"},{"Id":3,"Name":"doe"},{"Id":4,"Name":"pop"},{"Id":5,"Name":"ann"}]""") ?? new();
        #endregion

        modelBuilder.Entity<Department>().HasData(departments);
        modelBuilder.Entity<Ticket>().HasData(tickets);
        modelBuilder.Entity<Developer>().HasData(developers);

        //modelBuilder.Entity<OrderProduct>()
        //    .HasKey(op => new { op.OrderId, op.ProductId });
    }

}
