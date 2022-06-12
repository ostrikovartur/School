namespace School;

class Room
{
    public void Print()
    {
        Console.WriteLine($"Room number:{Number}, Floor: {Floor.Number}");
    }
    public int Number { get; set; }
    public RoomType Type { get; set; }
    public Floor Floor { get; set; }
}
