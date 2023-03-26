using JsonSubTypes;
using Newtonsoft.Json;
using System.Text;

namespace SchoolsTest.Models;

[JsonConverter(typeof(JsonSubtypes), "Job")]
[JsonSubtypes.KnownSubType(typeof(Student), nameof(Student))]
public class Employee : Person
{
    public IEnumerable<Position> Positions { get; set; }

    public Position CurrentPosition => Positions.FirstOrDefault();
    //public School School { get; set; }
    public Employee(string firstName, string lastName, int age, IEnumerable<Position> position)
        : base(firstName, lastName, age)
    {
        Positions = position;
    }
    public Employee()
    {

    }

    public ICollection<School> Schools { get; set; } = new HashSet<School>();
    //public ICollection<EmployeePosition> EmployeePositions { get; set; }
    //public Position? Job => Position.FirstOrDefault();

    public override string ToString()
    {
        return $"{LastName} {FirstName} {Age} {string.Join(",", Positions)}";
    }
}