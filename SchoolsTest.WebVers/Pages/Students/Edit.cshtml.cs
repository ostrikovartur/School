using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Students;

public class Edit : PageModel
{
    AppDbContext _dbcontext;
    private readonly IRepository<Student> _repository;
    public string Message { get; private set; } = "";

    public Edit(IRepository<Student> repository, AppDbContext dbContext)
    {
        _repository = repository;
        _dbcontext = dbContext;
    }
    public void OnGet()
    {
    }
    //public IActionResult OnPostUpdate(string firstName, string lastName, int age)
    //{
    //    if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
    //    {
    //        return NotFound("School not found");
    //    }

    //    if (!int.TryParse(schoolIdStr, out var schoolId))
    //    {
    //        return NotFound("Incorrect school Id");
    //    }
    //    var currentSchool = _dbcontext.Schools
    //        .Where(school => school.Id == schoolId)
    //        .SingleOrDefault();
    //    Models.Student student = new(firstName, lastName, age);
    //    var (valid, error) = currentSchool.AddStudent(student);
    //    if (valid)
    //    {
    //        Message = $"Student first and last name:{firstName} {lastName}";
    //    }
    //    _dbcontext.SaveChanges();
    //    return Redirect($"/schools/{schoolId}");
    //}
    //public IActionResult OnPostUpdate()
    //{
    //    _repository.
    //    return Redirect($"/students/list");
    //}
    public IActionResult OnPostDelete(Student student)
    {
        _repository.Delete(student);
        return Redirect($"/students/list");
    }
}

