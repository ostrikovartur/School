using Microsoft.EntityFrameworkCore;
using SchoolsTest.Models;

namespace SchoolsTest.Data;

public class AppDbContext : DbContext
{
    public DbSet<School> Schools { get; set; } = null!;
    public DbSet<Address> Address { get; set; } = null!;
    public DbSet<Floor> Floors { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    //public DbSet<Employee> Employees { get; set; } = null!;
    //public DbSet<EmployeePosition> EmployeePositions { get; set; } = null !;

    //public DbSet<Director> Directors { get; set; } = null!;
    //public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    //public DbSet<Position> Positions { get; set; } = null !;
    public Models.School? CurrentSchool { get; set; }

    //public Models.School? CurrentFloor { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new Configs.AddressConfig());
        modelBuilder.ApplyConfiguration(new Configs.SchoolConfig());
        modelBuilder.ApplyConfiguration(new Configs.FloorConfig());
        modelBuilder.ApplyConfiguration(new Configs.RoomConfig());
        //modelBuilder.ApplyConfiguration(new Configs.EmployeePositionConfig());
        //modelBuilder.ApplyConfiguration(new Configs.DirectorConfig());
        modelBuilder.ApplyConfiguration(new Configs.EmployeeConfig());
        modelBuilder.ApplyConfiguration(new Configs.PositionConfig());
        //modelBuilder.ApplyConfiguration(new Configs.TeacherConfig());
        modelBuilder.ApplyConfiguration(new Configs.StudentConfig());

        //modelBuilder.Entity<Employee>()
        //    .HasMany(t => t.Positions)
        //    .WithMany(t => t.Employees)
        //    .UsingEntity(j => j.ToTable("EmployeePosition"));
    }
    //public void SetSchools(IEnumerable<Models.School> schools)
    //{
    //    _schools = schools.ToList();
    //}

    //public void AddSchool(Models.School school)
    //{
    //    _schools.Add(school);
    //}
}
