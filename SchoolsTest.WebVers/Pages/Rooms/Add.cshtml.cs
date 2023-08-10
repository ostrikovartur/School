using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.ViewModels;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomAdd : PageModel
{
    private readonly AppDbContext _dbcontext;
    private readonly IRoomRepository _repository;
    private readonly IRepository<RoomType> _repositoryRoomType;
    private readonly IRepository<Floor> _floorRepository;
    public IEnumerable<Floor> Floors { get; set; }
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public int FloorId { get; set; }
    public string Message { get; private set; } = "";

    public RoomAdd(IRoomRepository repository, IRepository<RoomType> repositoryRoomType, IRepository<Floor> floorRepository, AppDbContext dbContext)
    {
        _repository = repository;
        _dbcontext = dbContext;
        _floorRepository = floorRepository;
        _repositoryRoomType = repositoryRoomType;
    }
    public void OnGet()
    {
        Message = "Write data about room";
        RoomTypes = _repositoryRoomType.GetAll();
    }

    [ValidateAntiForgeryToken]
    public IActionResult OnPost(RoomDto roomDto, int floorId /*int roomNumber, IEnumerable<RoomType> roomType*/)
    {
        var currentFloor = _floorRepository.Get(floorId);
        //var currentFloor = _dbcontext.Set<Floor>()
        //    .Where(floor => floor.Id == FloorId)
        //    .SingleOrDefault();
        //FloorId = floorId;

        if (currentFloor is null)
        {
            return NotFound("Floor not found");
        }

        var roomType = _repositoryRoomType.GetAll(rt => roomDto.RoomTypeIds.Contains(rt.Id));

        Models.Room room = new(roomDto.Number, roomType.ToArray(), currentFloor);
        var (valid, error) = currentFloor.AddRoom(room);
        if (!valid)
        {
            return BadRequest(error);
        }
        _dbcontext.SaveChanges();

        return Redirect($"/{floorId}/rooms");
    }
}
