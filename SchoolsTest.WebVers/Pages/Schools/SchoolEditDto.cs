using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Schools;

public class SchoolEditDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    //public string Address { get; set; }

    //public AddressDto Address { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int PostalCode { get; set; }

    //public string Country { get; set; }
    //public string City { get; set; }
    //public string Street { get; set; }
    //public int PostalCode { get; set; }
    public DateTime OpeningDate { get; set; }

}

//public class AddressDto
//{
//    public string Country { get; set; }
//    public string City { get; set; }
//    public string Street { get; set; }
//    public int PostalCode { get; set; }
//}