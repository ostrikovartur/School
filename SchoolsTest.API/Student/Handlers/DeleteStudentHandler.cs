using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.Student.Handlers;

public class DeleteStudentHandler
{
    public static async Task<IResult> Handle(IRepository<Models.Student> studentRepository, int id)
    {
        var student = await studentRepository.Get(id);

        if (student is null)
        {
            return Results.NotFound($"Student {id} not found");
        }

        await studentRepository.Delete(student);

        return Results.Ok();
    }
}
