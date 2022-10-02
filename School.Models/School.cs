using Newtonsoft.Json;
using System.Text;

namespace SchoolsTest.Models;

public class School : ILogger
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
            foreach (Employee employee in _employees)
            {
                if (employee is Director director)
                {
                    return director;
                }
            }
            return null;
        }
    }

    private readonly List<Floor> _floors;
    public IEnumerable<Floor> Floors => _floors;

    private readonly List<Employee> _employees;
    public IEnumerable<Employee> Employees => _employees;

    private ILogger _logger;
    public void SetLogger (ILogger logger)
    {
        _logger = logger;

        foreach (Floor floor in _floors)
        {
            floor.SetLogger(logger);
        }
        foreach (Employee employee in _employees)
        {
            employee.SetLogger(logger);
        }
    }
    public void LogInfo(string message) => Console.WriteLine(message);
    public void LogError(string message) => Console.WriteLine(message);

    public School(string name, Address address, DateOnly openingDate, ILogger logger)
        : this(name, address, openingDate.ToDateTime(TimeOnly.MinValue), new List<Floor>(), new List<Employee>())
    {
        SetLogger(logger);
    }

    [JsonConstructor]
    public School(string name, Address address, DateTime openingDate, IEnumerable<Floor> floors, IEnumerable<Employee> employees)
    {
        Name = name;
        Address = address;
        OpeningDate = openingDate;
        _floors = floors.ToList();
        _employees = employees.ToList();
    }
    public void AddFloor(Floor floor)
    {
        for (int i = 0; i < _floors.Count; i++)
        {
            if (_floors[i].Number == floor.Number)
            {
                _logger.LogError($"Floor {floor.Number} already exists");
                return;
            }
        }

        _floors.Add(floor);
    }
    public void AddEmployee (Employee employee)
    {
        Console.WriteLine($"Employee {employee.Job} {employee.FirstName} {employee.LastName} with age {employee.Age}");

        if (employee is Director && Director is not null)
        {
            _logger.LogError("Director already exist");
            return;
        }

        if (string.IsNullOrEmpty(employee.FirstName))
        {
            _logger.LogError("First name is not provided");
            return;
        }

        if (string.IsNullOrEmpty(employee.LastName))
        {
            _logger.LogError("Last name is not provided");
            return;
        }

        if (employee.Age < 18)
        {
            _logger.LogError("Employee shouldn`t be less then 18");
            return;
        }

        if (employee.Age > 65)
        {
            _logger.LogError("Employee should be less then 65");
            return;
        }

        for (int i = 0; i < _employees.Count; i++)
        {
            Employee emp = _employees[i];
            if (emp.FirstName == employee.FirstName && emp.LastName == employee.LastName && emp.Age == employee.Age)
            {
                _logger.LogError("*This employee already exists*");
                return;
            }
        }
        _employees.Add(employee);
        _logger.LogInfo("Director add");
    }

    public override string ToString()
    {
        StringBuilder sb = new ();
        sb.AppendLine($"School {Name}:");
        sb.AppendLine($"Total floors: {Floors.Count()}:");
        sb.AppendLine($"Total rooms: {Rooms.Count()}:");
        sb.AppendLine();
        sb.AppendLine("==========Rooms==========");
        foreach (Floor floor in _floors)
        {
            sb.AppendLine(floor.ToString());
        }

        sb.AppendLine();
        sb.AppendLine("==========Employees==========");
        foreach (Employee employee in _employees)
        {
            sb.AppendLine(employee.ToString());
        }
        return sb.ToString();
    }
}