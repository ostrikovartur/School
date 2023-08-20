using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;
using SchoolsTest.WebVers.Pages.Employees;

namespace SchoolsTest.WebVers.Pages.Students;

public class Edit : BasePageModel
{
    private readonly IRepository<Models.Student> _repository;
    public IEnumerable<School> Schools { get; set; }
    public IEnumerable<Models.Student> Students { get; set; }
    public School School { get; set; }
    public Models.Student Student { get; set; }

    public Edit(IRepository<Student> repository)
    {
        _repository = repository;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var schoolId = GetSchoolId();

        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        Student = await _repository.Get(id);

        if (Student is null)
        {
            return NotFound("Student is not found");
        }

        return Page();
    }
    public async Task<IActionResult> OnPostUpdate(StudentEditDto student)
    {
        var studentToUpdate = await _repository.Get(student.Id);

        if (studentToUpdate is null)
        {
            return NotFound("Student is not found");
        }

        studentToUpdate.SetNames(student.FirstName, student.LastName);
        studentToUpdate.SetAge(student.Age);

        await _repository.Update(studentToUpdate);
        return Redirect($"/students");
    }
    public async Task<IActionResult> OnPostDelete(StudentEditDto student)
    {
        var studentToDelete = await _repository.Get(student.Id);

        if (studentToDelete is null)
        {
            return NotFound("Student is not found");
        }

        await _repository.Delete(studentToDelete);
        return Redirect($"/students");
    }
}

