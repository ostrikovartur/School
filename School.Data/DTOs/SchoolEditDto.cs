using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Schools;

public record SchoolEditDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    //public string Address { get; set; }

    //public AddressDto Address { get; set; }
    public string Country { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public int PostalCode { get; init; }

    //public string Country { get; set; }
    //public string City { get; set; }
    //public string Street { get; set; }
    //public int PostalCode { get; set; }
    public DateTime OpeningDate { get; init; }

}

//public class AddressDto
//{
//    public string Country { get; set; }
//    public string City { get; set; }
//    public string Street { get; set; }
//    public int PostalCode { get; set; }
//}