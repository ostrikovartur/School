namespace SchoolsTest.API;

public static class Policies
{
    public const string SystemAdmin = "SystemAdminPolicy";
    public const string SchoolAdmin = "SchoolAdminPolicy";
}

public static class ClaimNames
{
    public const string Admin = "admin";
    public const string Employee = "employee";
}

public static class ClaimValues
{
    public const string SystemAdmin = nameof(SystemAdmin);
    public const string SchoolAdmin = nameof(SchoolAdmin);


    public static string[] AdminClaims = new[] { SchoolAdmin, SystemAdmin };

    public const string Director = nameof(Director);

    public static string[] EmployeeClaims = new[] { Director };
}