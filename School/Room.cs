namespace School;

public class Room
{
    public Room(int roomNumber, RoomType roomType, Floor floor)
    {
        Number = roomNumber;
        Type = roomType;
        Floor = floor;
    }

    public void Print()
    {
        Console.WriteLine($"Room number:{Number}, Floor: {Floor.Number}");
    }
    public int Number { get; set; }
    public RoomType Type { get; set; }
    public Floor Floor { get; set; }
}
