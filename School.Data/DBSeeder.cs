using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SchoolsTest.Models;

namespace SchoolsTest.Data;

public static class DBSeeder
{
    public static async Task SeedDB(AppDbContext dbContext)
    {
        await SeedRoomTypes(dbContext);
        await SeedSchools(dbContext);
        await SeedFloors(dbContext);
        await SeedRooms(dbContext);
        await SeedPositions(dbContext);
        await SeedEmployees(dbContext);
        await SeedStudents(dbContext);

        await dbContext.SaveChangesAsync();
    }

    public static async Task SeedSchools(AppDbContext dbContext)
    {
        if (dbContext.Schools.Any())
        {
            return;
        }

        dbContext.Schools.Add(new School("Malynivska", new Address("Ukraine", "Malynivka", "Schkilna", 22500), new DateTime(1999, 01, 01)));
        dbContext.Schools.Add(new School("Litynska", new Address("Ukraine", "Lityn", "Ushchenka", 12345), new DateTime(1998, 02, 02)));
        dbContext.Schools.Add(new School("Vinytska", new Address("Ukraine", "Vinytsya", "Yunosti", 22540), new DateTime(1995, 10, 12)));

        await dbContext.SaveChangesAsync();
    }

    public static async Task SeedFloors(AppDbContext dbContext)
    {
        if (dbContext.Floors.Any())
        {
            return;
        }

        foreach (var school in dbContext.Schools)
        {
            for (int i = 0; i < 5; i++)
            {
                dbContext.Floors.Add(new Floor(i + 1) { School = school });
            }
        }
        await dbContext.SaveChangesAsync();
    }

    public static async Task SeedRoomTypes(AppDbContext dbContext)
    {
        if (dbContext.RoomTypes.Any())
        {
            return;
        }
        
        dbContext.RoomTypes.Add(new RoomType("Math"));
        dbContext.RoomTypes.Add(new RoomType("Library"));
        dbContext.RoomTypes.Add(new RoomType("IT"));
        dbContext.RoomTypes.Add(new RoomType("Gym"));
        dbContext.RoomTypes.Add(new RoomType("Biology"));
    }

    public static async Task SeedRooms(AppDbContext dbContext)
    {
        if (dbContext.Rooms.Any())
        {
            return;
        }

        foreach (var floor in dbContext.Floors)
        {
            for (int i = 100; i < 105; i++)
            {
                dbContext.Rooms.Add(new Room(i + 1, floor));
            }
        }
    }

    public static async Task SeedPositions(AppDbContext dbContext)
    {
        if (dbContext.Positions.Any())
        {
            return;
        }

        dbContext.Positions.Add(new Position("Director"));
        dbContext.Positions.Add(new Position("Teacher"));
        dbContext.Positions.Add(new Position("Cleaner"));
        dbContext.Positions.Add(new Position("Cooker"));
        dbContext.Positions.Add(new Position("Petya"));
    }
    public static async Task SeedEmployees(AppDbContext dbContext)
    {
        if (dbContext.Employees.Any())
        {
            return;
        }

        dbContext.Employees.Add(new Employee("Tarasova", "Olena", 25));
        dbContext.Employees.Add(new Employee("Petrovich", "Petro", 80));
        dbContext.Employees.Add(new Employee("Apanasiy", "Olecksiy", 55));
        dbContext.Employees.Add(new Employee("Poroshenko", "Petro", 16));
        dbContext.Employees.Add(new Employee("Petrosyan", "Nikita", 16));
    }
    public static async Task SeedStudents(AppDbContext dbContext)
    {
        if (dbContext.Students.Any())
        {
            return;
        }

        foreach (var school in dbContext.Schools)
        {
            dbContext.Students.Add(new Student("Ostrikov", "Artur", 17) { School = school});
            dbContext.Students.Add(new Student("Nesteruk", "Michail", 16) { School = school });
            dbContext.Students.Add(new Student("Lishchyna", "Vlad", 15) { School = school });
            dbContext.Students.Add(new Student("Antkov", "Mykola", 17) { School = school });
            dbContext.Students.Add(new Student("Vityuk", "Volodimyr", 17) { School = school });
        }
    }

}
