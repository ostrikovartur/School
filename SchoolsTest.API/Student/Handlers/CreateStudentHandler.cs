using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Employees;
using SchoolsTest.WebVers.Pages.Students;

namespace SchoolsTest.API.Student.Handlers;

public class CreateStudentHandler
{
    public static async Task<IResult> Handle(IRepository<Models.Student> studentRepository,
        [FromBody] StudentAddDto studentDto,
        [FromRoute] int schoolId)
    {
        Models.Student student = new(studentDto.FirstName, studentDto.LastName, studentDto.Age)
        {
            SchoolId = schoolId
        };

        await studentRepository.Add(student);

        if (student is null)
        {
            return Results.NotFound($"Student not created");
        }

        return Results.Created($"/schools/{student.Id}", new StudentEditDto
        {
            Id = student.Id,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Age = studentDto.Age,
        });
    }
}
