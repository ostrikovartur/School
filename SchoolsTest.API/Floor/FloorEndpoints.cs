using SchoolsTest.API.Floor.Handlers;
using SchoolsTest.Models.Constants;
using SchoolsTest.WebVers.Pages.Floors;

namespace SchoolsTest.API.Floor;

public static class FloorEndpoints
{
    public static void Map(WebApplication app)
    {
        var manageGroup = app.MapGroup("/schools/{schoolId:int}/floors")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithTags("Floors Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.ManageFloor);
            });

        var infoGroup = app.MapGroup("/schools/{schoolId:int}/floors")
            .AddEndpointFilter<SchoolIdExistsFilter>()
            .WithTags("Floors Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.InfoFloor);
            });

        infoGroup.MapGet("", GetAllFloorsHandler.Handle)
            .WithSummary("Get all floors")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPost("", CreateFloorHandler.Handle)
            .WithSummary("Create new floor")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapDelete("{id}", DeleteFloorHandler.Handle)
            .WithSummary("Delete floor")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPut("{id}", UpdateFloorHandler.Handle)
            .WithSummary("Update floor")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);

        infoGroup.MapGet("{id}", InfoFloorHandler.Handle)
            .WithSummary("Get info about floor")
            .Produces<FloorDto>()
            .Produces(StatusCodes.Status404NotFound);
    }
}
