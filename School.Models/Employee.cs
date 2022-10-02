using JsonSubTypes;
using Newtonsoft.Json;

namespace SchoolsTest.Models;

[JsonConverter(typeof(JsonSubtypes), "Job")]
[JsonSubtypes.KnownSubType(typeof(Teacher), nameof(Teacher))]
[JsonSubtypes.KnownSubType(typeof(Director), nameof(Director))]
[JsonSubtypes.KnownSubType(typeof(Student), nameof(Student))]
public abstract class Employee : Person
{
    public ILogger _logger;
    public void SetLogger(ILogger logger)
    {
        _logger = logger;
    }
    protected Employee(string firstName, string lastName, int age, ILogger logger)
        : base(firstName, lastName, age)
    {
        SetLogger(logger);
    }

    public abstract string Job { get; }
    public override string ToString()
    {
        return $"{LastName} {FirstName} {Age} {Job}";
    }
}