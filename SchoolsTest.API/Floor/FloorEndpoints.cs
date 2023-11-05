using SchoolsTest.API.Floor.Handlers;
using SchoolsTest.WebVers.Pages.Floors;

namespace SchoolsTest.API.Floor;

public static class FloorEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/schools/{schoolId:int}/floors")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithTags("Floors Group")
            .WithOpenApi()
            .RequireAuthorization("SchoolAdminPolicy");

        group.MapGet("", GetAllFloorsHandler.Handle)
            .WithSummary("Get all floors")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("", CreateFloorHandler.Handle)
            .WithSummary("Create new floor")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("{id}", DeleteFloorHandler.Handle)
            .WithSummary("Delete floor")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPut("{id}", UpdateFloorHandler.Handle)
            .WithSummary("Update floor")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapGet("{id}", InfoFloorHandler.Handle)
            .WithSummary("Get info about floor")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);
    }
}
