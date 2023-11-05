namespace SchoolsTest.WebVers.Pages.Students;

public record StudentDto
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
}
