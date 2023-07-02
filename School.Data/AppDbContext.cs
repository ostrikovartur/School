using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using SchoolsTest.Models;

namespace SchoolsTest.Data;

public class AppDbContext : DbContext
{
    public School? CurrentSchool { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new Configs.AddressConfig());
        modelBuilder.ApplyConfiguration(new Configs.SchoolConfig());
        modelBuilder.ApplyConfiguration(new Configs.FloorConfig());
        modelBuilder.ApplyConfiguration(new Configs.RoomConfig());
        modelBuilder.ApplyConfiguration(new Configs.RoomTypeConfig());
        modelBuilder.ApplyConfiguration(new Configs.EmployeeConfig());
        modelBuilder.ApplyConfiguration(new Configs.PositionConfig());
        modelBuilder.ApplyConfiguration(new Configs.StudentConfig());
    }
}
