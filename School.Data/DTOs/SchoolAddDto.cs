namespace SchoolsTest.WebVers.Pages.Schools;

public record SchoolAddDto
{
    public string Name { get; init; }
    public string Country { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public int PostalCode { get; init; }
    public DateTime OpeningDate { get; init; }
}
