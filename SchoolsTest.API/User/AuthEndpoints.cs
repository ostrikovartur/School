using SchoolsTest.API.User.EmailManage;
using SchoolsTest.API.User.PasswordManage;
using SchoolsTest.Models.Constants;

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
                policies.RequireClaim(ClaimNames.Permission, ClaimValues.SystemAdminClaims);
            });

        group.MapPost("/changePassword", ChangePasswordHandler.Handle)
            .WithSummary("Change user password");

        group.MapPost("/resetPassword", ResetPasswordHandler.Handle)
            .WithSummary("Reset user password");

        group.MapPost("/setNewPassword", SetNewPasswordHandler.Handle)
            .WithSummary("Set new user password");

        group.MapPost("/confirmEmail", ConfirmEmail.Handle)
            .WithSummary("Confirm user email");
    }
}
