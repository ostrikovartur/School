using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using SchoolsTest.Models.Constants;

namespace SchoolsTest.API.User;

public static class AddClaimsHandler
{
    public static async Task<IResult> Handle(
        HttpContext context,
        UserManager<IdentityUser<int>> userManager,
        [FromBody] UserClaimRequest claimRequest)
    {
        var user = await userManager.FindByNameAsync(claimRequest.Username);

        if (user is null)
        {
            return Results.Unauthorized();
        }

        var userClaims = context.User.FindAll(c => c.Type == ClaimNames.Permission);

        // chech system admin can add claims to school admin only

        if (userClaims.Any(c => c.Value == ClaimValues.ManageAdmins)
            && !claimRequest.Claims.Any(c => c.Value == ClaimValues.ManageAdmins))
        {
            var claims = claimRequest.Claims.Select(claim => new Claim(claim.Key, claim.Value)).ToList();

            await userManager.AddClaimsAsync(user, claims);
        }

        // chech school admin can add claims to non-admin authorized only


        if (userClaims.Any(c => c.Value == ClaimValues.ManageSchoolUsers)
            && !claimRequest.Claims.Any(c => c.Value == ClaimValues.ManageAdmins))
        {
            var claims = claimRequest.Claims.Select(claim => new Claim(claim.Key, claim.Value)).ToList();

            await userManager.AddClaimsAsync(user, claims);
        }


        var result = await AssignClaims(ClaimValues.ManageSchool);

        if (result != Results.Empty)
        {
            return result;
        }

        result = await AssignClaims(ClaimValues.ManageEmployee);

        if (result != Results.Empty)
        {
            return result;
        }

        return Results.Ok();

        async Task<IResult> AssignClaims(string permission)
        {
            if (!userClaims.Any(ac => ac.Value == permission))
            {
                return Results.Empty;
            }

            foreach (var claim in claimRequest.Claims.Where(c => c.Key == ClaimNames.Permission))
            {
                var result = await userManager.AddClaimAsync(user, new Claim(claim.Key, claim.Value));

                if (!result.Succeeded)
                {
                    return Results.Problem(string.Join(";", result.Errors.Select(e => $"{e.Code}: {e.Description}")));
                }
            }

            return Results.Empty;
        }
    }
}

public sealed record UserClaimRequest(string Username, CustomClaim[] Claims);

public sealed record CustomClaim(string Key, string Value);