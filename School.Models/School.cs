using Newtonsoft.Json;
using SchoolsTest.Models.Interfaces;
using System.Text;

namespace SchoolsTest.Models;

public class School : BaseEntity
{
    public string Name { get; set; }
    public Address Address { get; set; }
    public DateTime OpeningDate { get; set; }
    
    [JsonIgnore]
    public IEnumerable<Room> Rooms
    {
        get
        {
            List<Room> allRooms = new List<Room>();
            foreach (Floor floor in Floors)
            {
                allRooms.AddRange(floor.Rooms);
            }
            return allRooms;
        }
    }

    [JsonIgnore]
    public Employee? Director
    {
        get
        {
            foreach (Employee employee in Employees)
            {
                if (employee is Director director)
                {
                    return director;
                }
            }
            return null;
        }
    }

    public ICollection<Floor> Floors { get; set; } = new HashSet<Floor>();
    public ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    public ICollection<Student> Students { get; set; } = new HashSet<Student>();

    public School()
    {

    }
    public School(string name, Address address, DateTime openingDate)
        : this(name, address, openingDate, new List<Floor>(), new List<Employee>(), new List<Student>())
    {
    }

    [JsonConstructor]
    public School(string name, Address address, DateTime openingDate, IEnumerable<Floor> floors, IEnumerable<Employee> employees, IEnumerable<Student> students)
    {
        Name = name;
        Address = address;
        OpeningDate = openingDate;
        Floors = floors.ToList();
        Employees = employees.ToList();
        Students = students.ToList();
    }

    public (bool IsValid, string? Error) AddFloor(Floor floor)
    {
        foreach (Floor flr in Floors)
        {
            if (flr.Number == floor.Number && flr.Id == floor.Id)
            {
                return (false, $"Floor {floor.Number} already exists");
            }
        }
        Floors.Add(floor);
        return (true, null);
    }

    public (bool IsValid, string? Error) AddEmployee(Employee employee)
    {
        if (employee is Director && Director is not null)
        {
            return (false, "Director already exist");
        }

        if (string.IsNullOrEmpty(employee.FirstName))
        {
            return (false, "First name is not provided");
        }

        if (string.IsNullOrEmpty(employee.LastName))
        {
            return (false, "Last name is not provided");
        }

        if (employee.Age < 18)
        {
            return (false, "Employee shouldn`t be less then 18");
        }

        if (employee.Age > 65)
        {
            return (false, "Employee should be less then 65");
        }
        foreach (Employee emp in Employees)
        {
            if (emp.FirstName == employee.FirstName && emp.LastName == employee.LastName && emp.Age == employee.Age)
            {
                return (false, "This employee already exist");
            }
        }
        Employees.Add(employee);
        return (true, null);
    }

    public (bool IsValid, string? Error) DeleteDirector()
    {
        var director = Director;

        if (director is null)
        {
            return (false, "Director not found");
        }

        Employees.Remove(director);

        return (true, null);
    }

    public (bool IsValid, string? Error) AddStudent(Student student)
    {

        if (string.IsNullOrEmpty(student.FirstName))
        {
            return (false, "First name is not provided");
        }

        if (string.IsNullOrEmpty(student.LastName))
        {
            return (false, "Last name is not provided");
        }

        if (student.Age < 16)
        {
            return (false, "Student shouldn`t be less then 16");
        }

        foreach (Student std in Students)
        {
            if (std.FirstName == student.FirstName && std.LastName == student.LastName && std.Age == student.Age)
            {
                return (false, "This student already exist");
            }
        }
        Students.Add(student);
        return (true, null);
    }

    public override string ToString()
    {
        StringBuilder sb = new ();
        sb.AppendLine($"School {Name}:");
        sb.AppendLine($"Total floors: {Floors.Count()}:");
        sb.AppendLine($"Total rooms: {Rooms.Count()}:");
        sb.AppendLine();
        sb.AppendLine("==========Rooms==========");
        foreach (Floor floor in Floors)
        {
            sb.AppendLine(floor.ToString());
        }

        sb.AppendLine();
        sb.AppendLine("==========Employees==========");
        foreach (Employee employee in Employees)
        {
            sb.AppendLine(employee.ToString());
        }
        return sb.ToString();
    }
}