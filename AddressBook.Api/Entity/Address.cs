namespace AddressBook.Api.Entity
{
    public class Address : BaseEntity
    {
        public string FullName { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }

        public Address()
        {
            FullName = string.Empty;
            Province = string.Empty;
            District = string.Empty;
            Neighborhood = string.Empty;
            Street = string.Empty;
            PhoneNumber = string.Empty;
        }

        public Address(string fullName, string province, string district,
            string neighborhood, string street, string phoneNumber)
        {
            FullName = fullName;
            Province = province;
            District = district;
            Neighborhood = neighborhood;
            Street = street;
            PhoneNumber = phoneNumber;
        }
    }
}