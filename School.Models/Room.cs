using Newtonsoft.Json;

namespace SchoolsTest.Models;

public class Room : BaseEntity
{
    public int Number { get; set; }

    [JsonIgnore]
    public Floor FloorNumber { get; set; }

    public RoomType Type { get; set; }

    public Room()
    {

    }
    public Room(int number, RoomType type, Floor floor)
    {
        Number = number;
        Type = type;
        FloorNumber = floor;
    }
    public override string ToString()
    {
        return $"Room: {Number}, {Type}";
    }
}
