using SchoolsTest.API.School.Handlers;
using SchoolsTest.Data.DTOs;
using SchoolsTest.Models.Constants;
using SchoolsTest.WebVers.Pages.Students;

namespace SchoolsTest.API.School;

public static class SchoolEndpoints
{
    public static void Map(WebApplication app)
    {
        var manageGroup = app.MapGroup("/schools")
            .WithTags("Schools Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.ManageSchool);
            });

        var infoGroup = app.MapGroup("/schools")
            .WithTags("Schools Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.InfoSchool);
            });

        infoGroup.MapGet("", GetAllSchoolsHandler.Handle)
            .WithSummary("Get all schools")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPost("", CreateSchoolHandler.Handle)
            .WithSummary("Create new school")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapDelete("{id}", DeleteSchoolHandler.Handle)
            .WithSummary("Delete school")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPut("{id}", UpdateSchoolHandler.Handle)
            .WithSummary("Update school")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);

        infoGroup.MapGet("{id}", InfoSchoolHandler.Handle)
            .WithSummary("Get info about school")
            .Produces<SchoolDto>()
            .Produces(StatusCodes.Status404NotFound);
        //group.MapGet("{id}", GetSchoolsEmployeesHandler.Handle);
    }
}
