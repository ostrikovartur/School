using SchoolsTest.API.Student.Handlers;
using SchoolsTest.Models.Constants;
using SchoolsTest.WebVers.Pages.Students;

namespace SchoolsTest.API.Student;

public static class StudentEndpoints
{
    public static void Map(WebApplication app)
    {
        var manageGroup = app.MapGroup("/schools/{schoolId:int}/students")
            .WithTags("Students Group")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.ManageStudent);
            });

        var infoGroup = app.MapGroup("/schools/{schoolId:int}/students")
            .WithTags("Students Group")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.InfoStudent);
            });

        infoGroup.MapGet("", GetAllStudentsHandler.Handle)
            .WithSummary("Get all students")
            .Produces<IEnumerable<StudentDto>>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPost("", CreateStudentHandler.Handle)
            .WithSummary("Create new student")
            .Produces<StudentDto>()
            .Produces(StatusCodes.Status404NotFound);
        
        manageGroup.MapDelete("{id}", DeleteStudentHandler.Handle)
            .WithSummary("Delete student")
            .Produces<StudentDto>()
            .Produces(StatusCodes.Status404NotFound);
        
        manageGroup.MapPut("{id}", UpdateStudentHandler.Handle)
            .WithSummary("Update student")
            .Produces<StudentDto>()
            .Produces(StatusCodes.Status404NotFound);

        infoGroup.MapGet("{id}", InfoStudentHandler.Handle)
            .WithSummary("Get info about student")
            .Produces<StudentDto>()
            .Produces(StatusCodes.Status404NotFound);
    }
}
