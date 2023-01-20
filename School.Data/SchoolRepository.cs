using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.Data;

public class SchoolRepository : Repository<School>, ISchoolRepository
{
    public SchoolRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public School? GetSchoolWithAddress(int id)
    {
        return _dbContext.Set<School>().Include(s => s.Address).SingleOrDefault(s => s.Id == id);
    }
    public School? GetSchoolId()
    {
        School? schoolId = .Request.Cookies["SchoolId"];
        return schoolId;
    }
}
