namespace SchoolsTest.Models.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<IEnumerable<Employee>> GetEmployeesWithPositions(int schoolId);
    Task<Employee> GetEmployeeWithPositions(int employeeId);
}
