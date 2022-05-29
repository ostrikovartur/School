namespace School
{
    class Employee
    {
        public void Print()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}