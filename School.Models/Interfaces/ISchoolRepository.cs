namespace SchoolsTest.Models.Interfaces;

public interface ISchoolRepository : IRepository<School>
{
    Task<School?> GetSchoolWithAddress(int id);
    //School DeleteDirector(int schoolId);
}
