namespace SchoolsTest.API.User;

public static class AuthEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/user")
            .WithTags("User Management Group");

        group.MapPost("/register", RegisterHandler.Handle)
            .WithSummary("Register user");

        group.MapPost("/login", LoginHandler.Handle)
            .WithSummary("Login user");

        group.MapPost("/claims", AddClaimsHandler.Handle)
            .WithSummary("Add claims to user")
            .RequireAuthorization(policies =>
            {
                policies.RequireClaim(ClaimNames.Admin, ClaimValues.AdminClaims);
            });
    }
}
