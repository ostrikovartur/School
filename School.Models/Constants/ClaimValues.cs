namespace SchoolsTest.Models.Constants;

public static class ClaimValues
{
    public const string ManageSchool = nameof(ManageSchool);
    public const string InfoSchool = nameof(InfoSchool);
    public const string ManagePosition = nameof(ManagePosition);
    public const string OperatePositionsInSchool = nameof(OperatePositionsInSchool);
    public const string InfoPosition = nameof(InfoPosition);
    public const string ManageEmployee = nameof(ManageEmployee);
    public const string InfoEmployee = nameof(InfoEmployee);
    public const string FullInfoEmployee = nameof(FullInfoEmployee);
    public const string ManageFloor = nameof(ManageFloor);
    public const string InfoFloor = nameof(InfoFloor);
    public const string ManageRoom = nameof(ManageRoom);
    public const string InfoRoom = nameof(InfoRoom);
    public const string ManageRoomType = nameof(ManageRoomType);
    public const string OperateRoomTypesInSchool = nameof(OperateRoomTypesInSchool);
    public const string InfoRoomTypes = nameof(InfoRoomTypes);
    public const string ManageStudent = nameof(ManageStudent);
    public const string InfoStudent = nameof(InfoStudent);
    public const string FullInfoStudent = nameof(FullInfoStudent);
    public const string ManageAdmins = nameof(ManageAdmins);
    public const string ManageSchoolUsers = nameof(ManageSchoolUsers);


    public static string[] SystemAdminClaims = new[] { ManageSchool, ManagePosition, ManageRoomType, ManageAdmins };

    public static string[] SchoolAdminClaims = new[] { ManageSchoolUsers, ManageEmployee, OperatePositionsInSchool, OperateRoomTypesInSchool, ManageFloor, ManageRoom, ManageStudent, FullInfoEmployee, FullInfoStudent };

    public static string[] EmployeeClaims = new[] { InfoSchool, InfoEmployee, InfoStudent, InfoFloor, InfoRoom, InfoPosition, InfoRoomTypes };
}