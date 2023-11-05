using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Floors;
using SchoolsTest.WebVers.Pages.Schools;

namespace SchoolsTest.API.User;

public static class RegisterHandler
{
    public static async Task<IResult> Handle(
        UserManager<IdentityUser<int>> userManager,
        SignInManager<IdentityUser<int>> signInManager,
        [FromQuery] string userName,
        [FromQuery] string password)
    {
        var user = new IdentityUser<int>(userName);

        var result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return Results.Problem(string.Join(";", result.Errors.Select(e => $"{e.Code}: {e.Description}")));
        }

        await signInManager.SignInAsync(user, isPersistent: true);

        return Results.Ok();
    }
}
