namespace School;

public class School
{
    public Address Address { get; set; }
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
    public int OpeningDate { get; set; }
    public string Name { get; set; }
    public IEnumerable<Floor> Floors => _floors;
    public Employee? Director
    {
        get
        {
            foreach (Employee employee in _employees)
            {
                Director? director = employee as Director;
                if (director is not null)
                {
                    return director;
                }
            }
            return null;
        }
    }

    private readonly List<Floor> _floors = new();
    public IEnumerable<Floor> Floor => _floors;

    private readonly List<Employee> _employees = new();
    public IEnumerable<Employee> Employees => _employees;
    private List<Room> _rooms;
    public School(string name, Address address, int openingDate)
    {
        Name = name;
        Address = address;
        OpeningDate = openingDate;
    }

    public void AddTeacher(string firstName, string lastName, int age)
    {
        Console.WriteLine($"=========Employee to add:===========");
        Console.WriteLine($"Adding teacher {firstName} {lastName} with age {age}");
        try
        {
            AddEmployee(new Teacher(firstName, lastName, age));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void AddDirector(string firstName, string lastName, int age)
    {
        Console.WriteLine($"=========Employee to add:===========");
        Console.WriteLine($"Adding director {firstName} {lastName} with age {age}");
        try
        {
            var director = new Director(firstName, lastName, age);
            if (director is Director && Director is not null)
            {
                Console.WriteLine("Error(The director already exists)");
                return;
            }

            AddEmployee(director);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void AddEmployee(Employee employee)
    {
        if (string.IsNullOrEmpty(employee.FirstName))
        {
            Console.WriteLine("First name is not provided");
            return;
        }

        if (string.IsNullOrEmpty(employee.LastName))
        {
            Console.WriteLine("Last name is not provided");
            return;
        }

        if (employee.Age < 1)
        {
            Console.WriteLine("Age can't be less than 1");
            return;
        }

        if (employee.Age < 18)
        {
            Console.WriteLine("Employee should be older than 18");
            return;
        }
        
        if (employee.Age > 65)
        {
            Console.WriteLine("Employee can't be older 65");
            return;
        }

        if (employee.Age > 115)
        {
            Console.WriteLine("Age can't be older 115");
            return;
        }

        for (int i = 0; i < _employees.Count; i++)
        {
            Employee emp = _employees[i];
            if (emp.FirstName == employee.FirstName && emp.LastName == employee.LastName && emp.Age == employee.Age)
            {
                Console.WriteLine("*This employee already exists*");
                Console.WriteLine("---------------------------------------------");
                return;
            }
        }
        _employees.Add(employee);
        Console.WriteLine("---------------------------------------------");
    }
    public void AddFloor(Floor floor)
    {
        for (int i = 0; i < _floors.Count; i++)
        {
            if (_floors[i].Number == floor.Number)
            {
                Console.WriteLine($"Floor {floor.Number} already exists");
                return;
            }
        }

        _floors.Add(floor);
    }
    public void AddSchool(School school)
    {
        school.Name = Console.ReadLine();
    }
    public void Print()
    {
        Console.WriteLine();
        Console.WriteLine($"==========Rooms==========");
        foreach (Floor floor in _floors)
        {
            floor.Print();
        }

        Console.WriteLine();
        Console.WriteLine("==========Employees==========");
        foreach (Employee employee in _employees)
        {
            employee.Print();
        }
    }
    public void Info()
    {
        Console.WriteLine("==========School and director names===========");
        Console.WriteLine($"Name {Name}");
        Console.WriteLine($"Director name: {Director.FirstName} {Director.LastName}");
        Console.WriteLine("===============================================");
        Console.WriteLine("======== All Employees ========");
        foreach (Employee employee in Employees)
        {
            employee.Print();
        }
        Console.WriteLine("=================================");
        Console.WriteLine($"========== All rooms on school:{Rooms.Count()}===========");
        foreach (Floor floor in Floors)
        {
            floor.Print();
        }
        Console.WriteLine("===========================================================");
    }
}