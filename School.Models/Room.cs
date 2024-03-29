﻿namespace SchoolsTest.Models;

public class Room : BaseEntity
{
    public ICollection<RoomType> RoomTypes { get; set; }

    public int Number { get; set; }
    public int FloorId { get; set; }
    public Floor Floor { get; set; }
    public int[] RoomTypeIds => RoomTypes.Select(x => x.Id).ToArray();

    public Room()
    {

    }

    public Room(int number, ICollection<RoomType> type, Floor floor)
    {
        Number = number;
        RoomTypes = type;
        Floor = floor;
    }
    public Room(int number, Floor floor)
    {
        Number = number;
        Floor = floor;
    }
    public void SetNumber(int number)
    {
        Number = number;
    }
    public void SetFloor(int floorId)
    {
        FloorId = floorId;
    }
    public void SetRoomTypes(ICollection<RoomType> roomTypes)
    {
        RoomTypes.Clear();

        foreach (var roomType in roomTypes)
        {
            RoomTypes.Add(roomType);
        }
    }

    public override string ToString()
    {
        return $"Room: {Number}, {RoomTypes}";
    }
}
