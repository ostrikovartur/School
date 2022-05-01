namespace School;

class School
{
    //public Malynovska SchoolName = Malynovska;
    //public string classMath = Math;
    //public string schoolHall = Hall;
    //public string medicalClass = Medical;
    //public string diningRoom = Dining;
    //public string schoolFloor1 = Floor1;
    //public string schoolFloor2 = Floor2;
    public Address Address { get; set; }
    public string Name { get; set; }
    public ICollection<Room> Rooms { get; set; }
    public DateOnly OpeningDate { get; set; }
    public ICollection<Floor> Floors { get; set; }
    public Employee Director { get; set; }
    public ICollection<Employee> Employees { get; set; }
}

public class Address
{
    public string City { get; set; }
    public string Country { get; set; }
    public string Street { get; set; }
    public int PostalCode { get; set; }
}

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
}

public class Room
{
    public int Number { get; set; }
    public RoomType Type { get; set; }
    public Floor Floor { get; set; }
}

public class Floor
{
    public int Number { get; set; }
    public ICollection<Room> Rooms { get; set; }
}

[Flags]
public enum RoomType
{
    Regular = 1,
    Math = 2,
    Biology = 4,
    Literature = 8,
    Informatic = 16,
    Gym = 32,
    Physics = 64,
    Hall = 128,
}
