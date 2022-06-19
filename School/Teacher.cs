namespace School;

public class Teacher : Employee
{
    public override string Job => "Teacher";
    public List<string> _subject;
    public ICollection<string> Subjects => _subject;
    public Teacher(string firstName, string lastName, int age) 
        : base(firstName, lastName, age)
    {
        _subject = new List<string>();
    }
        
    public void AddSubject(string subject)
    {
        _subject.Add(subject);
    }
}
