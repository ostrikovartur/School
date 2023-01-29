using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Rooms;

public class RoomsList : PageModel
{
    private readonly IRepository<Room> _repository;
    public IEnumerable<Room> Rooms { get; set; }

    public int FloorId { get; set; }
    public Floor FloorNumber { get; set; }

    public RoomsList(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public void OnGet(int floorId)
    {
        FloorId = floorId;
        Rooms = _repository.GetAll(r => r.FloorNumber.Id == floorId);
    }
}
