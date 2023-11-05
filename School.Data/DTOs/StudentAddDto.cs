namespace SchoolsTest.WebVers.Pages.Students;

public record StudentAddDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
}
