using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.Data;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    private readonly AppDbContext _dbContext;
    public EmployeeRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Employee> GetSchoolEmployees(int schoolId)
    {
        Employee[] directors = _dbContext.Set<Director>()
            .Where(d => d.SchoolId == schoolId)
            .ToArray();

        Employee[] teachers = _dbContext.Set<Teacher>()
            .Where(d => d.SchoolId == schoolId)
            .ToArray();

        var employees = new List<Employee>();
        employees.AddRange(teachers);
        employees.AddRange(directors);

        return employees;
    }
}
