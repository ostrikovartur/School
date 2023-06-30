using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Employee>> GetEmployeesWithPositions(int schoolId)
    {
        var employees = await _dbContext.Set<Employee>()
            .Include(e => e.Positions)
            .Where(e => e.Schools.All(s => s.Id == schoolId))
            .ToListAsync();

        return employees;
    }
    public Employee? GetEmployeeWithPositions(int employeeId)
    {
        return _dbContext.Set<Employee>()
            .Include(p => p.Positions)
            .FirstOrDefault(e => e.Id == employeeId);
    }
}
