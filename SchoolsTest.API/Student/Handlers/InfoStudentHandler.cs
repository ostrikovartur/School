using SchoolsTest.Models.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SchoolsTest.API.Student.Handlers;

public class InfoStudentHandler
{
    public static async Task<IResult> Handle(IRepository<Models.Student> studentRepository, int id)
    {
        var student = await studentRepository.Get(id);

        if (student is null)
        {
            return Results.NotFound($"Student {id} not found");
        }
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return Results.Json(student, options);
    }
}
