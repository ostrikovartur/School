using System.Text.Json.Serialization;
using SchoolsTest.Models;

namespace SchoolsTest.Data;

public class Context
{
    private List<Models.School> _schools;

    public IEnumerable<Models.School> Schools => _schools;

    [JsonIgnore]
    public Models.School? CurrentSchool { get; set; }

    public Context()
    {
        _schools = new();
    }

    [JsonConstructor]
    public Context(IEnumerable<Models.School> schools)
    {
        SetSchools(schools);
    }

    public async Task SetSchools(IEnumerable<Models.School> schools)
    {
        _schools = schools.ToList();
    }

    public async Task AddSchool(Models.School school)
    {
        _schools.Add(school);
    }
}
