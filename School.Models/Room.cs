using Newtonsoft.Json;

namespace SchoolsTest.Models;

public class Room : BaseEntity
{
    public int Number { get; set; }

    [JsonIgnore]
    public Floor Floor { get; set; }

    public RoomType Type { get; set; }

    public Room()
    {

    }
    public Room(int number, RoomType type, Floor floor)
    {
        Number = number;
        Type = type;
        Floor = floor;
    }
    public override string ToString()
    {
        return $"Room: {Number}, {Type}";
    }
}
