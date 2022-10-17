namespace Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; }
    public string ZipCode { get; }
    public string City { get; }

    public Address(string street, string zipCode, string city)
    {
        Street = street;
        ZipCode = zipCode;
        City = city;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return ZipCode;
        yield return City;
    }
}
