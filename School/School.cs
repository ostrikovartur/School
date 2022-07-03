namespace School;

class School
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
    public DateOnly OpeningDate { get; set; }
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

    public IEnumerable<Employee> Employees => _employees;
    private List<Floor> _floors;
    private List<Employee> _employees;
    private List<Room> _rooms;
    public School()
    {
        _floors = new List<Floor>();
        _employees = new List<Employee>();
        _rooms = new List<Room>();
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
            var emp = _employees[i];
            if (emp.FirstName == employee.FirstName && emp.LastName == employee.LastName && emp.Age == employee.Age)
            {
                Console.WriteLine("Error(This employee already exists");
                return ;
            }
        }
        _employees.Add(employee);
    }
    public void AddFloor(Floor floor)
    {
        _floors.Add(floor);
    }
    public void Print()
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
