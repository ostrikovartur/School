using JsonSubTypes;
using Newtonsoft.Json;

namespace SchoolsTest.Models;

[JsonConverter(typeof(JsonSubtypes), "Job")]
//[JsonSubtypes.KnownSubType(typeof(Teacher), nameof(Teacher))]
//[JsonSubtypes.KnownSubType(typeof(Director), nameof(Director))]
[JsonSubtypes.KnownSubType(typeof(Student), nameof(Student))]
public class Employee : Person
{
    protected Employee(string firstName, string lastName, int age)
        : base(firstName, lastName, age)
    {
        //Job = job;
    }
    protected Employee()
    {

    }
    public School School { get; set; }
    public ICollection<School> Schools { get; set; } = new HashSet<School>();
    public ICollection<Position>? Positions { get; set; } = new HashSet<Position>();
    public Position Job => Positions.FirstOrDefault();

    public override string ToString()
    {
        return $"{LastName} {FirstName} {Age} {Job}";
    }
}