using Microsoft.EntityFrameworkCore;
using SchoolsTest.Models;

namespace SchoolsTest.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }


        private List<Models.School> _schools;

        public Models.School? CurrentSchool { get; set; }

        //public Models.School? CurrentFloor { get; set; }

        private readonly string _connString;
        public AppDbContext(string connString)
        {
            _connString = connString;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new Configs.AddressConfig());
            modelBuilder.ApplyConfiguration(new Configs.SchoolConfig());
            modelBuilder.ApplyConfiguration(new Configs.FloorConfig());
            modelBuilder.ApplyConfiguration(new Configs.RoomConfig());
            modelBuilder.ApplyConfiguration(new Configs.DirectorConfig());
            modelBuilder.ApplyConfiguration(new Configs.EmployeeConfig());
            modelBuilder.ApplyConfiguration(new Configs.TeacherConfig());
            modelBuilder.ApplyConfiguration(new Configs.StudentConfig());
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
}
