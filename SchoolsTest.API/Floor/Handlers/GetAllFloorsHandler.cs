using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SchoolsTest.API.Floor.Handlers;

public class GetAllFloorsHandler
{
    public static async Task<IResult> Handle(IFloorRepository floorRepository)
    {
        var floors = await floorRepository.GetAll();

        if (floors is null)
        {
            return Results.NotFound($"Floors not found");
        }
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return Results.Json(floors, options);
    }
}
