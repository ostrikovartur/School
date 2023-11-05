using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.Position.Handlers;

public static class AddPositionToSchoolHandler
{
    public static async Task<IResult> Handle(IRepository<Models.Position> positionRepository,SchoolRepository schoolRepository, int id)
    {
        var position = await positionRepository.Get(id);

        if (position is null)
        {
            return Results.NotFound($"Position not found");
        }

        var school = schoolRepository.Get(id);

        return Results.Json(position);
    }
}
