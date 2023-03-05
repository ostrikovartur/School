//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using SchoolsTest.Data;
//using SchoolsTest.Models.Interfaces;
//using SchoolsTest.Models;

//namespace SchoolsTest.WebVers.Pages.Employees;

//public class Add : PageModel
//{
//    AppDbContext _dbcontext;
//    //private readonly IRepository<Director> _directorRepository;

//    //private readonly IRepository<Teacher> _teacherRepository;
//    //public IEnumerable<Director> Directors { get; set; }
//    //public IEnumerable<Teacher> Teachers { get; set; }
//    public Employee Employee { get; set; }

//    public Add(IRepository<Director> directorRepository, IRepository<Teacher> teacherRepository, AppDbContext dbContext)
//    {
//        _directorRepository = directorRepository;
//        _teacherRepository = teacherRepository;
//        _dbcontext = dbContext;
//    }
//    public void OnGet()
//    {
//        Directors = _directorRepository.GetAll();
//        Teachers = _teacherRepository.GetAll();
//    }

//    public IActionResult OnPost()
//    {
//        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
//        {
//            return NotFound("School not found");
//        }

//        if (!int.TryParse(schoolIdStr, out var schoolId))
//        {
//            return NotFound("Incorrect school Id");
//        }
//        //if (Employee.Job == )
//        //{

//        //}
//        //if ()
//        //{

//        //}

//        var currentSchool = _dbcontext.Schools
//            .Where(school => school.Id == schoolId)
//            .SingleOrDefault();
//        if (currentSchool.Director is not null)
//        {
//            throw new Exception("Director already exist");
//        }


//        //Models.Director director = new(directorDto.FirstName, directorDto.LastName, directorDto.Age);
//        //if (director.FirstName == currentSchool.Employee.FirstName)
//        //var (valid, error) = currentSchool.AddEmployee(director);
//        //director.School = currentSchool;
//        _dbcontext.SaveChanges();
//        return Redirect($"/employees");
//    }
//}

