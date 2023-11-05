namespace SchoolsTest.WebVers.Pages.RoomTypes;

public record RoomTypeAddDto
{
    public const int BaseRoomTypeId = 1;
    public string Name { get; init; }
    public int SchoolId { get; init; }
}
