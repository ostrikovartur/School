using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Positions;

namespace SchoolsTest.API.Position.Handlers;

public class UpdatePositionHandler
{
    public static async Task<IResult> Handle (IRepository<Models.Position> positionRepository, [FromBody] PositionAddDto positionDto, int id)
    {
        var positionToUpdate = await positionRepository.Get(id);

        if (positionToUpdate is null)
        {
            return Results.NotFound($"Position {id} not found");
        }

        positionToUpdate.Name = positionDto.Name;

        await positionRepository.Update(positionToUpdate);

        return Results.Json(positionToUpdate);
    }
}
