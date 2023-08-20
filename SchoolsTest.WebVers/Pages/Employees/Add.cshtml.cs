using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;
using System.IO;

namespace SchoolsTest.WebVers.Pages.Employees;

public class Add : PageModel
{
    private readonly IRepository<Position> _positionsRepository;
    private readonly ISchoolRepository _schoolRepository;
    private readonly AppDbContext _dbContext;

    public IEnumerable<Position> Positions { get; set; }

    public Add(IRepository<Position> positionsRepository,
        ISchoolRepository schoolRepository,
        AppDbContext dbContext)
    {
        _positionsRepository = positionsRepository;
        _schoolRepository = schoolRepository;
        _dbContext = dbContext;
    }

    public async Task OnGet()
    {
        Positions = await _positionsRepository.GetAll();
    }

    public async Task<IActionResult> OnPost(EmployeeAddDto employeeDto)
    {
        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
        {
            return NotFound("School not found");
        }

        if (!int.TryParse(schoolIdStr, out var schoolId))
        {
            return NotFound("Incorrect school Id");
        }
        
        var currentSchool = await _schoolRepository.Get(schoolId);

        var positions = await _positionsRepository.GetAll(p => employeeDto.PositionIds.Contains(p.Id));

        Models.Employee employee = new(employeeDto.FirstName, employeeDto.LastName, employeeDto.Age, positions.ToArray());
        var (valid, error) = currentSchool.AddEmployee(employee);

        //employee.School = currentSchool;
        _dbContext.SaveChanges();

        return Redirect($"/employees");
    }
}

