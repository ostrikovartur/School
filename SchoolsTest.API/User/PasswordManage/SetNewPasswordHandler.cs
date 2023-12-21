using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SchoolsTest.API.User.PasswordManage;

public static class SetNewPasswordHandler
{
    public static async Task<IResult> Handle(
        UserManager<IdentityUser<int>> userManager,
        [FromBody] SetNewPasswordRequest authRequest)
    {
        var user = await userManager.FindByNameAsync(authRequest.UserName);

        if (user is null)
        {
            return Results.NotFound($"User {authRequest.UserName} not found");
        }

        if (!authRequest.IsPasswordConfirmed())
        { 
            return Results.BadRequest("Confirmed password doesn't match new one");
        }

        var setPassword = await userManager.ResetPasswordAsync(user, authRequest.ResetToken, authRequest.NewPassword);

        if (!setPassword.Succeeded)
        {
            return Results.Problem(string.Join(";", setPassword.Errors.Select(e => $"{e.Code}: {e.Description}")));
        }

        return Results.Ok();
    }
}
