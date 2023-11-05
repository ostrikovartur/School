using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.Position.Handlers;

public class GetAllPositionsHandler
{
    public static async Task<IResult> Handle(IRepository<Models.Position> positionRepository)
    {
        var positions = await positionRepository.GetAll();

        if (positions is null)
        {
            return Results.NotFound($"Positions not found");
        }

        return Results.Json(positions);
    }
}
