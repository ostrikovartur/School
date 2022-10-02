namespace SchoolsTest.Models
{
    public class Director : Employee
    {
        public Director(string firstName, string lastName, int age, ILogger logger)
            : base(firstName, lastName, age, logger)
        {
            SetLogger(logger);
        }
        public override string Job => "Director";
    }
}