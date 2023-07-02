using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.ViewModels;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomAdd : PageModel
{
    AppDbContext _dbcontext;
    private readonly IFloorRepository _repository;
    private readonly IRepository<RoomType> _repositoryRoomType;
    public IEnumerable<Floor> Floors { get; set; }
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public int FloorId { get; set; }
    public string Message { get; private set; } = "";

    public RoomAdd(IFloorRepository repository,IRepository<RoomType> repositoryRoomType, AppDbContext dbContext)
    {
        _repository = repository;
        _dbcontext = dbContext;
        _repositoryRoomType = repositoryRoomType;
        RoomTypes = _repositoryRoomType.GetAll();
    }
    public void OnGet()
    {
        Message = "Write data about room";
        Floors = _repository.GetAll();
    }
    public IActionResult OnPost(RoomDto roomDto, int floorId /*int roomNumber, IEnumerable<RoomType> roomType*/)
    {
        var currentFloor = _repository.Get(floorId);
        //var currentFloor = _dbcontext.Set<Floor>()
        //    .Where(floor => floor.Id == FloorId)
        //    .SingleOrDefault();
        //FloorId = floorId;

        if (currentFloor is null)
        {
            return NotFound("Floor not found");
        }

        var roomType = _repositoryRoomType.GetAll(rt => roomDto.RoomTypeIds.Contains(rt.Id));
        //var currentSchool = _schoolRepository.Get(schoolId);

        //var positions = _positionsRepository.GetAll(p => employeeDto.PositionIds.Contains(p.Id));

        //Models.Employee employee = new(employeeDto.FirstName, employeeDto.LastName, employeeDto.Age, positions.ToArray());
        //var (valid, error) = currentSchool.AddEmployee(employee);

        Models.Room room = new(roomDto.Number, roomType,currentFloor);
        var (valid, error) = currentFloor.AddRoom(room);
        if (!valid)
        {
            return BadRequest(error);
        }
        _dbcontext.SaveChanges();
        return Redirect($"/{currentFloor}/rooms");
    }
}
