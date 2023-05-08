using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;
using SchoolsTest.WebVers.ViewModels;
using System.IO;

namespace SchoolsTest.WebVers.Pages.Employees;

public class Add : PageModel
{
    AppDbContext _dbcontext;
    private readonly IRepository<Position> _positionsRepository;
    public IEnumerable<Position> Positions { get; set; }
    public Add(IRepository<Position> positionsRepository, AppDbContext dbContext)
    {
        _positionsRepository = positionsRepository;
        _dbcontext = dbContext;
    }
    public void OnGet()
    {
        Positions = _positionsRepository.GetAll();
    }

    public IActionResult OnPost(EmployeeDto employeeDto)
    {
        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
        {
            return NotFound("School not found");
        }

        if (!int.TryParse(schoolIdStr, out var schoolId))
        {
            return NotFound("Incorrect school Id");
        }
        
        var currentSchool = _dbcontext.Schools
            .Where(school => school.Id == schoolId)
            .SingleOrDefault();

        var positions = _positionsRepository.GetAll(p => employeeDto.PositionIds.Contains(p.Id));

        Models.Employee employee = new(employeeDto.FirstName, employeeDto.LastName, employeeDto.Age, employeeDto.PositionIds);
        var (valid, error) = currentSchool.AddEmployee(employee);

        //employee.School = currentSchool;
        _dbcontext.SaveChanges();
        return Redirect($"/employees");
    }
}

