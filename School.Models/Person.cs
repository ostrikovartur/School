namespace SchoolsTest.Models;

public abstract class Person : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }
    protected Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
    public Person()
    {

    }

    public void SetNames(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void SetAge(int age)
    {
        if (age > 100)
        {
            throw new Exception("Person can't be older than 100 years");
        }

        Age = age;
    }
}
