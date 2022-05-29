namespace School
{
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
        public Employee Director { get; set; }
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
            _employees.Add(employee);
        }
        public void AddFloor(Floor floor)
        {
            _floors.Add(floor);
        }
        public void Print()
        {
            Console.WriteLine($"Name {Name}");
            Console.WriteLine($"Director name: {Director.LastName} {Director.FirstName}");
            foreach (Employee employee in Employees)
            {
                employee.Print();
            }
            Console.WriteLine($"All rooms on school:{Rooms.Count()}");
            foreach (Floor floor in Floors)
            {
                floor.Print();
            }
        }
    }
}