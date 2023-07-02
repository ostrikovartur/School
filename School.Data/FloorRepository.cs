using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.Data;

public class FloorRepository : Repository<Floor>, IRepository<Floor>
{
    private readonly AppDbContext _dbContext;

    public FloorRepository(AppDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
