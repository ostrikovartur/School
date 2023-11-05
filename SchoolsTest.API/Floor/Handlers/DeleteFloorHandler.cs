using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Floors;

namespace SchoolsTest.API.Floor.Handlers;

public class DeleteFloorHandler
{
    public static async Task<IResult> Handle(IFloorRepository floorRepository, int id)
    {
        var floor = await floorRepository.Get(id);

        if (floor is null)
        {
            return Results.NotFound($"Floor {id} not found");
        }

        await floorRepository.Delete(floor);
        return Results.Ok();
    }
}
