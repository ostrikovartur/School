namespace SchoolsTest.Models;

public class Position : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<School> Schools { get; set; }
    public Position(string name)
    {
        Name = name;
    }
    public Position() { }
}
