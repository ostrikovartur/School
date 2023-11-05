using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolsTest.Models.Interfaces;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolsTest.API.Floor.Handlers;

public static class InfoFloorHandler
{
    public static async Task<IResult> Handle(
        [FromRoute] int schoolId,
        IFloorRepository floorRepository,
        int id)
    {        
        var floor = await floorRepository.Get(id);

        //if (floor.SchoolId != schoolId)
        //{
        //    return Results.BadRequest("Floor not exist in this school");
        //}

        if (floor is null)
        {
            return Results.NotFound($"Floor {id} not found");
        }

        var content = JsonConvert.SerializeObject(floor, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        return Results.Content(content, Application.Json, Encoding.UTF8);
    }
}
