namespace SchoolsTest.Data.DTOs;

public record SchoolDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Country { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public int PostalCode { get; init; }
    public DateTime OpeningDate { get; init; }
}
