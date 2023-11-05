using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.Position.Handlers;

public class DeletePositionHandler
{
    public static async Task<IResult> Handle(IRepository<Models.Position> positionRepository, int id)
    { 
        var position = await positionRepository.Get(id);

        if (position is null)
        {
            return Results.NotFound($"Position {id} not found");
        }

        await positionRepository.Delete(position);

        return Results.Ok();
    }
}
