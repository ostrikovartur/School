using JsonSubTypes;
using Newtonsoft.Json;

namespace SchoolsTest.Models;

[JsonConverter(typeof(JsonSubtypes), "Job")]
[JsonSubtypes.KnownSubType(typeof(Teacher), nameof(Teacher))]
[JsonSubtypes.KnownSubType(typeof(Director), nameof(Director))]
[JsonSubtypes.KnownSubType(typeof(Student), nameof(Student))]
public abstract class Employee : Person
{
    protected Employee(string firstName, string lastName, int age)
        : base(firstName, lastName, age)
    {
    }
    protected Employee()
    {

    }
    public ICollection<School> Schools { get; set; } = new HashSet<School>();
    public abstract string Job { get; }
    protected Employee(School school, int schoolId)
    {
        Schools.Add(school);
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName} {Age} {Job}";
    }
}