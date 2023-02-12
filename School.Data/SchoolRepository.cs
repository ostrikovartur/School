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
    //public School? DeleteDirector(int schoolId)
    //{
    //    var school = _dbContext.Set<School>().Include(s => s.Employees).SingleOrDefault(s => s.Id == schoolId);

    //    //school.Employees.Remove(school.Director);
    //    school.DeleteDirector();

    //    _dbContext.SaveChanges();

    //    return school;
    //}
    //public School? GetSchoolId(int id)
    //{
    //    id = Request.Cookies;
    //    return 
    //}
}
