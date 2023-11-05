using SchoolsTest.Models.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SchoolsTest.API.Student.Handlers;

public class GetAllStudentsHandler
{
    public static async Task<IResult> Handle(IRepository<Models.Student> studentRepository)
    {
        var students = await studentRepository.GetAll();

        if (students is null)
        {
            return Results.NotFound($"Students not found");
        }
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return Results.Json(students, options);
    }
}
