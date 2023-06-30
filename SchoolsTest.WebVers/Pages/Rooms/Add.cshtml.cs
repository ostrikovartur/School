using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomAdd : PageModel
{
    AppDbContext _dbcontext;
    private readonly IRepository<Floor> _repository;
    private readonly IRepository<RoomType> _repositoryRoomType;
    public IEnumerable<Floor> Floors { get; set; }
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public int SchoolId { get; set; }
    public int FloorId { get; set; }
    public string Message { get; private set; } = "";

    public RoomAdd(IRepository<Floor> repository,IRepository<RoomType> repositoryRoomType, AppDbContext dbContext)
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
    public IActionResult OnPost(int floorId, int roomNumber, IEnumerable<RoomType> roomType)
    {
        var currentFloor = _dbcontext.Set<Floor>()
            .Where(floor => floor.Id == floorId)
            .SingleOrDefault();
        //FloorId = floorId;

        if (currentFloor is null)
        {
            return NotFound("Floor not found");
        }

        roomType = RoomTypes;

        Models.Room room = new(roomNumber, roomType,currentFloor);
        var (valid, error) = currentFloor.AddRoom(room);
        if (!valid)
        {
            return BadRequest(error);
        }
        _dbcontext.SaveChanges();
        return Redirect($"/{floorId}/rooms");
    }
}
