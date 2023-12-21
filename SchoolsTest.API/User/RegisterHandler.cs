using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolsTest.Data;
using SchoolsTest.Models.Constants;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Floors;
using SchoolsTest.WebVers.Pages.Schools;
using System.Security.Claims;

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

        var addEmail = await userManager.GetEmailAsync(user);

        var confirmEmailToken = await userManager.GenerateEmailConfirmationTokenAsync(user);

        var addClaims = await userManager.AddClaimsAsync(user, ClaimValues.EmployeeClaims.Select(c => new Claim(ClaimNames.Permission, c)).ToArray());

        if (!result.Succeeded)
        {
            return Results.Problem(string.Join(";", result.Errors.Select(e => $"{e.Code}: {e.Description}")));
        }

        await signInManager.SignInAsync(user, isPersistent: true);

        return Results.Ok(new { token = confirmEmailToken });
    }
}
