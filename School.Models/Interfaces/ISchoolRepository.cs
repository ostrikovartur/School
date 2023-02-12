namespace SchoolsTest.Models.Interfaces;

public interface ISchoolRepository : IRepository<School>
{
    School? GetSchoolWithAddress(int id);
    //School DeleteDirector(int schoolId);
}
