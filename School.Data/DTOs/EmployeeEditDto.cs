using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Employees;

public record EmployeeEditDto
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
    public int[] PositionIds { get; init; } = Array.Empty<int>();
}
