namespace SchoolsTest.WebVers.Pages.RoomTypes;

public record RoomTypeEditDto
{
    public const int BaseRoomTypeId = 1;
    public int Id { get; init; }
    public string Name { get; init; }
    public int SchoolId { get; init; }
}
