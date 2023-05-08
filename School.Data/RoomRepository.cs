using Microsoft.EntityFrameworkCore;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.Data;

public class RoomRepository : Repository<Room>, IRoomRepository
{
    public RoomRepository(AppDbContext dbContext)
        : base(dbContext)
    {
    }

    public Room? GetRoomWithRoomTypes(int roomId)
    {
        return _dbContext.Rooms.Include(r => r.RoomTypes).FirstOrDefault(r => r.Id == roomId);
    }
}
