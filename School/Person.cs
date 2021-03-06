namespace School;

public abstract class Person
{
    public int Id { get; set; }
    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }
    protected Person (string firstName, string lastName, int age )
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}
