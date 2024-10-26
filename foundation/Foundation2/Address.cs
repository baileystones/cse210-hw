class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

//DISCLAIMER: I used ChatGPT to help me with this part because I wasn't sure about the naming conventions & uniformity 
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string DisplayAll()
    {
        return $"\n{_streetAddress} {_city},{_stateOrProvince} {_country}";
    }
}