namespace SchoolsTest.Models;

public class Student : Person
{
    private readonly List<string> _subjects;
    public ICollection<string> Subjects => _subjects;
    public School School { get; set; }
    public Student(string firstName, string lastName, int age)
        : base(firstName, lastName, age)
    {
        _subjects = new List<string>();
    }
    public void AddSubject(string subject)
    {
        _subjects.Add(subject);
    }
}
