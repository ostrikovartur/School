using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.School.Handlers;

public class InfoSchoolHandler
{
    public static async Task<IResult> Handle(ISchoolRepository schoolRepository, int id)
    {
        var school = await schoolRepository.Get(id);

        if (school is null)
        {
            return Results.NotFound($"School {id} not found");
        }

        return Results.Json(school);
    }
}
