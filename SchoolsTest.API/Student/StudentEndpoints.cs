using SchoolsTest.API.Student.Handlers;
using SchoolsTest.WebVers.Pages.Students;

namespace SchoolsTest.API.Student;

public static class StudentEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/schools/{schoolId:int}/students")
            .WithTags("Students Group")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithOpenApi();

        group.MapGet("", GetAllStudentsHandler.Handle)
            .WithSummary("Get all students")
            .Produces<IEnumerable<StudentDto>>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("", CreateStudentHandler.Handle)
            .WithSummary("Create new student")
            .Produces<StudentDto>()
            .Produces(StatusCodes.Status404NotFound);
        
        group.MapDelete("{id}", DeleteStudentHandler.Handle)
            .WithSummary("Delete student")
            .Produces<StudentDto>()
            .Produces(StatusCodes.Status404NotFound);
        
        group.MapPut("{id}", UpdateStudentHandler.Handle)
            .WithSummary("Update student")
            .Produces<StudentDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapGet("{id}", InfoStudentHandler.Handle)
            .WithSummary("Get info about student")
            .Produces<StudentDto>()
            .Produces(StatusCodes.Status404NotFound);
    }
}
