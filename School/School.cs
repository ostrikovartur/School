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
    public void AddEmployee(Employee employee)
    {
        /* Метод має добавляти учителя і директора
         * при цьому перевіряти, якщо діректор уже існує
         * тоді замість добавлення вивести повідомлення з помилкою
         * створити повідомлення з помилкою якщо директор уже існує
         * добавити перевірку на існування директора
         * додати код для додавання директора в випадку якщо директор не існує
         * додати код на ігнорування додавання директора в випадку якщо він уже існує
         * додати вчителя і перевірити виконання коду з присутністью вчителя
         * додати вчителя в список employees
         */ 
        _employees.Add(employee);
        Console.WriteLine($"=========Employee to add:===========");
        employee.Print();
        if (Director is null)
        {
            _employees.Add(Director);
        }
        else
        {
            
        }
        
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
