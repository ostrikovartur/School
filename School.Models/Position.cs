namespace SchoolsTest.Models;

public class Position : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Employee>? Employees { get; set; }
    //public Employee Director { get; set; }
    public Position(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public Position(string name)
    {
        Name = name;
    }

    //public string Description { get; set; }
}
