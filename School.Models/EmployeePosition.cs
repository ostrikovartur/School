namespace SchoolsTest.Models;

public class EmployeePosition
{
    public int EmployeeId { get; set; }
    public int PositionId { get; set; }
    public Employee? Employee { get; set; }
    public Position? Positions { get; set; }
}
