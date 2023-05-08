namespace SchoolsTest.Models.Interfaces;

public interface IRoomRepository : IRepository<Room>
{
    Room? GetRoomWithRoomTypes(int roomId);
}
