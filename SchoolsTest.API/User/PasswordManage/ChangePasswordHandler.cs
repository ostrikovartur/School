using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace SchoolsTest.API.User.PasswordManage;

public static class ChangePasswordHandler
{
    public static async Task<IResult> Handle(
        UserManager<IdentityUser<int>> userManager,
        SignInManager<IdentityUser<int>> signInManager,
        [FromBody] ChangePasswordRequest authRequest)
    {
        var user = await userManager.FindByNameAsync(authRequest.UserName);

        if (user is null)
        {
            return Results.Unauthorized();
        }

        var result = await signInManager.CheckPasswordSignInAsync(user,
           authRequest.Password,
           true);

        if (!result.Succeeded)
        {
            return Results.Unauthorized();
        }

        if (result.IsLockedOut)
        {
            return Results.BadRequest("User is locked out");
        }

        if (authRequest.IsPasswordConfirmed())
        {
            return Results.BadRequest("Confirmed password doesn't match new one");
        }

        var changedPassword = await userManager.ChangePasswordAsync(user, authRequest.Password, authRequest.NewPassword);

        if (!changedPassword.Succeeded)
        {
            return Results.Problem(string.Join(";", changedPassword.Errors.Select(e => $"{e.Code}: {e.Description}")));
        }

        return Results.Ok();
    }
}
