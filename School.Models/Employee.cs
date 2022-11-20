using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

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
    public School School { get; set; }
    public abstract string Job { get; }
    public override string ToString()
    {
        return $"{LastName} {FirstName} {Age} {Job}";
    }
}