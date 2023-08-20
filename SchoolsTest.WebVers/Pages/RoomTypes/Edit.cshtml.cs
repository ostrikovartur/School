using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.RoomTypes;

public class Edit : BasePageModel
{
    private readonly IRepository<RoomType> _roomTypeRepository;
    public IEnumerable<RoomType> RoomTypes { get; set; }
    public IEnumerable<School> Schools { get; set; }
    public School School { get; set; }
    public RoomType RoomType { get; set; }

    public Edit(IRepository<RoomType> repository)
    {
        _roomTypeRepository = repository;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var schoolId = GetSchoolId();

        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        RoomType = await _roomTypeRepository.Get(id);

        if (RoomType is null)
        {
            return NotFound("Room type is not found");
        }

        return Page();
    }
    public async Task<IActionResult> OnPostUpdate(RoomTypeEditDto roomType)
    {
        var roomTypeId = roomType.Id;

        var roomTypeToUpdate = await _roomTypeRepository.Get(roomTypeId);
        if (roomTypeToUpdate is null)
        {
            return NotFound("Room type is not found");
        }

        roomTypeToUpdate.Name = roomType.Name;

        await _roomTypeRepository.Update(roomTypeToUpdate);
        return Redirect($"/roomTypes");
    }

    public async Task<IActionResult> OnPostDelete(RoomTypeEditDto roomType)
    {
        var roomTypeId = roomType.Id;

        var roomTypeToUpdate = await _roomTypeRepository.Get(roomTypeId);
        if (roomTypeToUpdate is null)
        {
            return NotFound("Room type is not found");
        }

        await _roomTypeRepository.Delete(roomTypeToUpdate);
        return Redirect($"/roomTypes");
    }
}
