//using Azure;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using SchoolsTest.Data;
//using SchoolsTest.Models;
//using SchoolsTest.Models.Interfaces;

//namespace SchoolsTest.WebVers.Pages.Employees;

//public class DirectorAdd : PageModel
//{
//    AppDbContext _dbcontext;
//    private readonly IRepository<Director> _directorRepository;

//    private readonly IRepository<Teacher> _teacherRepository;
//    public IEnumerable<Director> Directors { get; set; }

//    public IEnumerable<Teacher> Teachers { get; set; }
//    public string Message { get; private set; } = "";

//    public DirectorAdd(IRepository<Director> directorRepository, IRepository<Teacher> teacherRepository, AppDbContext dbContext)
//    {
//        _directorRepository = directorRepository;
//        _teacherRepository = teacherRepository;
//        _dbcontext = dbContext;
//    }
//    public void OnGet()
//    {
//        Message = "Write data about director";
//        Directors = _directorRepository.GetAll();
//        Teachers = _teacherRepository.GetAll();
//    }

//    public IActionResult OnPost(DirectorDto directorDto)
//    {
//        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
//        {
//            return NotFound("School not found");
//        }

//        if (!int.TryParse(schoolIdStr, out var schoolId))
//        {
//            return NotFound("Incorrect school Id");
//        }

//        var currentSchool = _dbcontext.Schools
//            .Where(school => school.Id == schoolId)
//            .SingleOrDefault();
//        if (currentSchool.Director is not null)
//        {
//            throw new Exception("Director already exist");
//        }


//        Models.Director director = new(directorDto.FirstName, directorDto.LastName, directorDto.Age);
//        //if (director.FirstName == currentSchool.Employee.FirstName)
//        //if (type == "Director")
//        //{
//        //    if (employees.Any(e => e.Job == "Director"))
//        //    {
//        //        ErrorMessage = "Director already exist";
//        //        return Page();
//        //    }

//        //    employee = new Director(firstName, lastName, age);

//        //    var director = employee as Director;
//        //    director!.School = school;
//        //}

//        //if (type == "Teacher")
//        //{
//        //    employee = new Teacher(firstName, lastName, age);
//        //    var teacher = employee as Teacher;
//        //    teacher!.School = school;
//        //}
//        var (valid, error) = currentSchool.AddEmployee(director);
//        director.School = currentSchool;
//        _dbcontext.SaveChanges();
//        return Redirect($"/schools/{schoolId}");
//    }
//}
