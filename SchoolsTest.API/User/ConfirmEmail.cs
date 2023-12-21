using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models.Constants;
using System.Security.Claims;

namespace SchoolsTest.API.User;

public class ConfirmEmail
{
    public static async Task<IResult> Handle(
        UserManager<IdentityUser<int>> userManager,
        [FromBody] ConfirmEmailRequest authRequest)
    {
        var user = await userManager.FindByNameAsync(authRequest.UserName);

        if (user is null)
        {
            return Results.NotFound($"User {authRequest.UserName} not found");
        }

        var result = await userManager.ConfirmEmailAsync(user, authRequest.ConfirmToken);

        if (!result.Succeeded)
        {
            return Results.Problem(string.Join(";", result.Errors.Select(e => $"{e.Code}: {e.Description}")));
        }

        return Results.Ok();
    }
}
