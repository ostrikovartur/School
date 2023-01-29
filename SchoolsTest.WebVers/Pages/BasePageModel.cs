using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchoolsTest.WebVers.Pages
{
    public abstract class BasePageModel : PageModel
    {
        protected int? GetSchoolId()
        {
            var schoolIdStr = HttpContext.Request.Cookies["SchoolId"];

            return int.TryParse(schoolIdStr, out var schoolId) ? schoolId : null;
        }
    }
}
