using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SchoolsTest.API.User;

public static class LoginHandler
{
    public static async Task<IResult> Handle(
        UserManager<IdentityUser<int>> userManager,
        SignInManager<IdentityUser<int>> signInManager,
        [FromBody] AuthRequest authRequest)
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

        var claims = new List<Claim> 
        {
            new Claim(ClaimTypes.Name, user.UserName) 
        };

        var userClaims = await userManager.GetClaimsAsync(user);

        var expiresIn = TimeSpan.FromMinutes(2);
        var expiresAt = DateTime.UtcNow.Add(expiresIn);

        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims.Union(userClaims),
            expires: expiresAt,
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));


        string token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return Results.Ok(new
        {
            access_token = token,
            expiresIn = expiresIn.TotalSeconds
        });
    }
}
