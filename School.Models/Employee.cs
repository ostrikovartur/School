using JsonSubTypes;
using Newtonsoft.Json;

namespace SchoolsTest.Models;

[JsonConverter(typeof(JsonSubtypes), "Job")]
[JsonSubtypes.KnownSubType(typeof(Student), nameof(Student))]
public class Employee : Person
{
    public ICollection<School> Schools { get; set; } = new HashSet<School>();
    public ICollection<Position> Positions { get; set; }
    public int[] PositionIds => Positions.Select(x => x.Id).ToArray();

    public Employee(string firstName, string lastName, int age, ICollection<Position> position)
        : base(firstName, lastName, age)
    {
        Positions = position;
    }
    public Employee()
    {

    }

    public Employee(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {
    }

    public void SetPositions(ICollection<Position> positions)
    {
        Positions.Clear();

        foreach (var position in positions)
        {
            Positions.Add(position);
        }
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName} {Age} {string.Join(",", Positions)}";
    }
}