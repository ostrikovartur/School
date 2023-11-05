using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Schools;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SchoolsTest.API.School.Handlers;

public class UpdateSchoolHandler
{
    public static async Task<IResult> Handle(ISchoolRepository schoolRepository, int id, [FromBody] SchoolEditDto schoolDto)
    {
        var schoolToUpdate = await schoolRepository.Get(id);

        if (schoolToUpdate is null)
        {
            return Results.NotFound($"School {id} not found");
        }

        schoolToUpdate.Address = new Address
        {
            Country = schoolDto.Country,
            City = schoolDto.City,
            Street = schoolDto.Street,
            PostalCode = schoolDto.PostalCode,
        };

        schoolToUpdate.Name = schoolDto.Name;
        schoolToUpdate.OpeningDate = schoolDto.OpeningDate;
        schoolToUpdate.Address.Country = schoolDto.Country;
        schoolToUpdate.Address.City = schoolDto.City;
        schoolToUpdate.Address.Street = schoolDto.Street;
        schoolToUpdate.Address.PostalCode = schoolDto.PostalCode;

        await schoolRepository.Update(schoolToUpdate);
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return Results.Json(schoolToUpdate, options);
    }
}
