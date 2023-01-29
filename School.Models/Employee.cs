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
    public School School { get; set; }
    public int SchoolId { get; set; }
    public abstract string Job { get; }
    protected Employee(School school, int schoolId)
    {
        School = school;
        SchoolId = schoolId;
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName} {Age} {Job}";
    }
}