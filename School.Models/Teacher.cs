namespace SchoolsTest.Models;

public class Teacher : Employee
{
    public override string Job => "Teacher";

    private readonly List<string> _subjects;
    public ICollection<string> Subjects => _subjects;

    public Teacher(string firstName, string lastName, int age, ILogger logger)
        : base(firstName, lastName, age, logger)
    {
        _subjects = new List<string>();
        SetLogger(logger);
    }

    public void AddSubject(string subject)
    {
        _subjects.Add(subject);
    }
}
