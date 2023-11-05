using Microsoft.EntityFrameworkCore;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.Data;

public class SchoolRepository : Repository<School>, ISchoolRepository
{
    public SchoolRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<School?> GetSchoolWithAddress(int id)
    {
        return await DbContext.Set<School>().Include(s => s.Address).SingleOrDefaultAsync(s => s.Id == id);
    }

}
