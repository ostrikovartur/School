using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Data.DTOs;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API;

public class SchoolIdExistsFilter : IEndpointFilter 
{
    public ISchoolRepository _schoolRepository;

    public SchoolIdExistsFilter (ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var schoolIdRoute = context.HttpContext.Request.RouteValues["schoolId"];

        _ = int.TryParse(schoolIdRoute.ToString(), out int schoolId);

        var school = await _schoolRepository.Get(schoolId);
        
        if (string.IsNullOrEmpty(schoolId.ToString()))
        {
            return Results.BadRequest("SchoolId not provided");
        }

        if (school is null)
        {
            return Results.NotFound("School not found(filter)");
        }
        return await next(context);
    }
}
