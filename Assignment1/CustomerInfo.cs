namespace Assignment1;

// First Name,Last Name,Street Number,Street,City,Province,Postal Code,Country,Phone Number,email Address 
public class CustomerInfo
{
    public CustomerInfo()
    {
    }

    public CustomerInfo(string firstName, string lastName, string streetNumber, string street, string city,
        string province, string country, string postalCode, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        StreetNumber = streetNumber;
        Street = street;
        City = city;
        Province = province;
        PostalCode = postalCode;
        Country = country;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StreetNumber { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    // public override string ToString()
    // {
    //     return base.ToString();
    // }

    /*
     * Here incomplete record is a data that is missing any of the required field,
     */
    private static bool ContainsCompleteRecord(string[] customerDetails)
    {
        if (customerDetails.Length < 10) return false;
        return true;
    }

    public string CustomerInfoToCsv()
    {
        return
            $"{FirstName},{LastName},{StreetNumber},{Street},{City},{Province},{PostalCode},{Country}, {PhoneNumber},{Email}";
    }


    public static CustomerInfo CreateCustomerInfo(string[] customerDetails)
    {
        if (!ContainsCompleteRecord(customerDetails)) return null;

        // Here empty or null string are considered incomplete
        foreach (var customerDetail in customerDetails)
            if (string.IsNullOrEmpty(customerDetail))
                return null;

        // First Name,Last Name,Street Number,Street,City,Province,Postal Code,Country,Phone Number,email Address 
        return new CustomerInfo
        {
            FirstName = customerDetails[0],
            LastName = customerDetails[1],
            StreetNumber = customerDetails[2],
            Street = customerDetails[3],
            City = customerDetails[4],
            Province = customerDetails[5],
            PostalCode = customerDetails[6],
            Country = customerDetails[7],
            PhoneNumber = customerDetails[8],
            Email = customerDetails[9]
        };
    }
}