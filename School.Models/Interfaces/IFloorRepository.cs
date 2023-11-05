namespace SchoolsTest.Models.Interfaces;

public interface IFloorRepository : IRepository<Floor>
{
    Task<IEnumerable<Floor>> GetSchoolFloors(int schoolId);
}
