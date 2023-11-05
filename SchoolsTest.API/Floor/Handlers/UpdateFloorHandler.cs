using SchoolsTest.Data.DTOs;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Employees;
using Microsoft.AspNetCore.Mvc;
using SchoolsTest.WebVers.Pages.Floors;
using SchoolsTest.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SchoolsTest.API.Floor.Handlers;

public class UpdateFloorHandler
{
    public static async Task<IResult> Handle(IFloorRepository floorRepository, [FromBody] FloorAddDto floorDto, int id)
    {
        var floorToUpdate = await floorRepository.Get(id);

        if (floorToUpdate is null)
        {
            return Results.NotFound($"Floor {id} not found");
        }

        floorToUpdate.Number = floorDto.Number;

        await floorRepository.Update(floorToUpdate);

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return Results.Json(floorToUpdate, options);
    }
}
