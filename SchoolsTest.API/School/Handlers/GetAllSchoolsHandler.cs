using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.School.Handlers;

public class GetAllSchoolsHandler
{
    public static async Task<IResult> Handle(ISchoolRepository schoolRepository)
    {
        var schools = await schoolRepository.GetAll();

        if (schools is null)
        {
            return Results.NotFound($"Schools not found");
        }

        return Results.Json(schools);
    }
}
