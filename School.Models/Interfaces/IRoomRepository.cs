namespace SchoolsTest.Models.Interfaces;

public interface IRoomRepository : IRepository<Room>
{
    Task<Room?> GetRoomWithRoomTypes(int roomId);
    Task<IEnumerable<Room>> GetRoomsWithTypes(int schoolId);
}
