using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.School.Handlers;

public class DeleteSchoolHandler
{
    public static async Task<IResult> Handle(ISchoolRepository schoolRepository, int id)
    {
        var school = await schoolRepository.Get(id);

        if (school is null)
        {
            return Results.NotFound($"School {id} not found");
        }

        await schoolRepository.Delete(school);
        return Results.Ok();
    }
}
