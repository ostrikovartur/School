using Newtonsoft.Json;
using SchoolsTest.Models;

namespace SchoolsTest.Data;

public class SchoolRepository
{
    private readonly Context _ctx;
    private readonly string _fileName;
    private readonly ILogger _logger;

    public SchoolRepository(Context ctx, string fileName, ILogger logger)
    {
        _ctx = ctx;
        _fileName = fileName;
        _logger = logger;
        LoadData();
    }

    private void LoadData()
    {
        if (!File.Exists(_fileName))
        {
            return;
        }

        var content = File.ReadAllText(_fileName);
        if (string.IsNullOrEmpty(content))
        {
            return;
        }

        var ctx = JsonConvert.DeserializeObject<Context>(content);
        if (ctx is null)
        {
            return;
        }
        _ctx.SetSchools(ctx.Schools);

        foreach (var school in ctx.Schools)
        {
            school.SetLogger(_logger);
        }
        
    }

    public IEnumerable<Models.School> GetSchools()
    {
        if (!_ctx.Schools.Any())
        {
            _logger.LogError("Schools is not create, create one or more schools before select school");//!!!!!
            LoadData();
        }
        return _ctx.Schools;
    }

    public Models.School? GetSchool(string name)
    {
        return _ctx.Schools.Where(s => s.Name == name).SingleOrDefault();
    }

    public Models.School? GetCurrentSchool()
    {
        return _ctx.CurrentSchool;
    }

    public void SetCurrentSchool(Models.School? school)
    {
        _ctx.CurrentSchool = school;
    }

    public void AddSchool(Models.School school)
    {
        _ctx.AddSchool(school);
        SetCurrentSchool(school);
        SaveContext();
    }

    public void AddFloorToCurrentSchool(Floor floor)
    {
        _ctx.CurrentSchool?.AddFloor(floor);
        SaveContext();
    }

    public Floor? GetFloor(int floorNumber)
    {
        return _ctx.CurrentSchool?.Floors.Where(f => f.Number == floorNumber).FirstOrDefault();
    }

    public void AddRoomToCurrentSchool(Room room, Floor floor)
    {
        floor.AddRoom(room);
        SaveContext();
    }

    public void AddEmployeeToCurrentSchool(Employee employee)
    {
        _ctx.CurrentSchool?.AddEmployee(employee);
        SaveContext();
    }
    private void SaveContext()
    {
        var json = JsonConvert.SerializeObject(_ctx, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        File.WriteAllText(_fileName, json);
    }
}
