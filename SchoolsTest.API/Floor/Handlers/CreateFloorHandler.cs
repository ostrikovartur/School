using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Floors;

namespace SchoolsTest.API.Floor.Handlers;

public static class CreateFloorHandler
{
    public static async Task<IResult> Handle(
        IFloorRepository floorRepository,
        [FromBody] FloorAddDto floorDto,
        [FromRoute] int schoolId)
    {
        Models.Floor floor = new()
        {
            Number = floorDto.Number,
            SchoolId = floorDto.SchoolId,
        };

        await floorRepository.Add(floor);
        
        if (floor is null)
        {
            return Results.NotFound($"Floor not created");
        }

        return Results.Created($"/schools/{floorDto.SchoolId}/floors/{floor.Id}", new FloorEditDto
        {
            Id = floor.Id,
            Number = floorDto.Number,
            SchoolId = floorDto.SchoolId,
        });
    }
}
