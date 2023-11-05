using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Data.DTOs;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;
using SchoolsTest.WebVers.Pages.Schools;

namespace SchoolsTest.API.School.Handlers;

public class CreateSchoolHandler
{
    public static async Task<IResult> Handle(ISchoolRepository schoolRepository,
           [FromBody] SchoolAddDto schoolDto)
    {
        Address address = new()
        {
            Country = schoolDto.Country,
            City = schoolDto.City,
            Street = schoolDto.Street,
            PostalCode = schoolDto.PostalCode,
        };

        //School school = new(schoolDto.Name,address,schoolDto.OpeningDate);

        var school = new Models.School()
        {
            Name = schoolDto.Name,
            Address = address,
            OpeningDate = schoolDto.OpeningDate
        };

        await schoolRepository.Add(school);

        if (school is null)
        {
            return Results.NotFound($"School not created");
        }

        return Results.Created($"/schools/{school.Id}", new SchoolDto
        {
            Id = school.Id,
            Name = school.Name,
            Country = school.Address.Country,
            City = school.Address.City,
            Street = school.Address.Street,
            PostalCode = school.Address.PostalCode,
            OpeningDate = school.OpeningDate
        });
    }
}
