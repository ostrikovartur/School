using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Positions;

namespace SchoolsTest.API.Position.Handlers;

public class CreatePositionHandler
{
    public static async Task<IResult> Handle (IRepository<Models.Position> positionRepository, [FromBody] PositionAddDto positionDto)
    {
        var position = new Models.Position()
        {
            Name = positionDto.Name,
        };

        await positionRepository.Add(position);

        if (position is null)
        {
            return Results.NotFound($"Position not created");
        }

        return Results.Json(position);
    }
}
