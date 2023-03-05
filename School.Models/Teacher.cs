//namespace SchoolsTest.Models;

//public class Teacher : Employee
//{
//    public override string Job => "Teacher";

//    private readonly List<string> _subjects;
//    public int SchoolId { get; set; }
//    public School School { get; set; }
//    //public ICollection<School> Schools { get; set; } = new HashSet<School>();
//    public ICollection<string> Subjects => _subjects;

//    public Teacher(string firstName, string lastName, int age)
//        : base(firstName, lastName, age)
//    {
//        _subjects = new List<string>();
//    }
//    public Teacher() { }

//    public void AddSubject(string subject)
//    {
//        _subjects.Add(subject);
//    }
//}
