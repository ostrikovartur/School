namespace SchoolsTest.Models.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<IEnumerable<Employee>> GetEmployeesWithPositions(int schoolId);
    Employee GetEmployeeWithPositions(int employeeId);
}
