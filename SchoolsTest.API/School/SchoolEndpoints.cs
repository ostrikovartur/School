using SchoolsTest.API.School.Handlers;
using SchoolsTest.Data.DTOs;
using SchoolsTest.WebVers.Pages.Students;

namespace SchoolsTest.API.School;

public static class SchoolEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/schools")
            .WithTags("Schools Group")
            .WithOpenApi();

        group.MapGet("", GetAllSchoolsHandler.Handle)
            .WithSummary("Get all schools")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("", CreateSchoolHandler.Handle)
            .WithSummary("Create new school")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("{id}", DeleteSchoolHandler.Handle)
            .WithSummary("Delete school")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPut("{id}", UpdateSchoolHandler.Handle)
            .WithSummary("Update school")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapGet("{id}", InfoSchoolHandler.Handle)
            .WithSummary("Get info about school")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);
        //group.MapGet("{id}", GetSchoolsEmployeesHandler.Handle);
    }
}
