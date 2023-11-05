using Microsoft.EntityFrameworkCore;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.Data;

public class FloorRepository : Repository<Floor>, IFloorRepository
{
    public FloorRepository(AppDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IEnumerable<Floor>> GetSchoolFloors(int schoolId)
    {
        return await DbContext.Floors
            .Where(f => f.SchoolId == schoolId)
            .ToListAsync();
    }
}
