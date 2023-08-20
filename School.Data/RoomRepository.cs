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

    public async Task<Room?> GetRoomWithRoomTypes(int roomId)
    {
        return await _dbContext.Set<Room>()
            .Include(r => r.RoomTypes)
            .FirstOrDefaultAsync(r => r.Id == roomId);
    }
    public async Task<IEnumerable<Room>> GetRoomsWithTypes(int schoolId)
    {
        var rooms = await _dbContext.Set<Room>()
            .Include(r => r.RoomTypes)
            .Where(r => r.Floor.SchoolId == schoolId)
            .ToListAsync();

        return rooms;
    }
    //public async Task<IEnumerable<Room>> GetFloorId(int schoolId)
    //{
    //    var floorId = await _dbContext
    //}
    //protected int? GetSchoolId()
    //{
    //    var schoolIdStr = HttpContext.Request.Cookies["SchoolId"];

    //    return int.TryParse(schoolIdStr, out var schoolId) ? schoolId : null;
    //}
}
