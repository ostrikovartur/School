using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Students;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SchoolsTest.API.Student.Handlers;

public class UpdateStudentHandler
{
    public static async Task<IResult> Handle(IRepository<Models.Student> studentRepository, [FromBody] StudentAddDto studentDto, int id)
    {
        var studentToUpdate = await studentRepository.Get(id);

        if (studentToUpdate is null)
        {
            return Results.NotFound($"Student {id} not found");
        }

        studentToUpdate.SetNames(studentDto.FirstName, studentDto.LastName);
        studentToUpdate.SetAge(studentDto.Age);

        await studentRepository.Update(studentToUpdate);

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return Results.Json(studentToUpdate, options);
    }
}
