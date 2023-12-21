using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SchoolsTest.API.User.PasswordManage;

public static class ResetPasswordHandler
{
    public static async Task<IResult> Handle(
        UserManager<IdentityUser<int>> userManager,
        [FromBody] ChangePasswordRequest authRequest)
    {
        var user = await userManager.FindByNameAsync(authRequest.UserName);

        if (user is null)
        {
            return Results.NotFound($"User {authRequest.UserName} not found");
        }

        var result = await userManager.GeneratePasswordResetTokenAsync(user);

        return Results.Ok(new { token = result });
    }
}
