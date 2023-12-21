namespace SchoolsTest.API.User;

public record AuthRequest(string UserName, string Password, string Email);

public sealed record ChangePasswordRequest(string NewPassword, string ConfirmedPassword, string UserName, string Password, string Email)
    : AuthRequest(UserName, Password, Email)
{
    public bool IsPasswordConfirmed()
    {
        return NewPassword == ConfirmedPassword;
    }
}

public sealed record SetNewPasswordRequest(string NewPassword, string ConfirmedPassword, string UserName, string ResetToken, string Email)
{
    public bool IsPasswordConfirmed()
    {
        return NewPassword == ConfirmedPassword;
    }
}
public sealed record ConfirmEmailRequest(string UserName, string ConfirmToken);
