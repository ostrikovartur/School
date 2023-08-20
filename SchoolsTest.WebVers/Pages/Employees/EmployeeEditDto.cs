using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Employees;

public class EmployeeEditDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int[] PositionIds { get; set; } = Array.Empty<int>();
}
