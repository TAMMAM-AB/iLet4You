public class Landlords // collection class
{
    private readonly List<Landlord> _landlords = new(); // stores user records

    // load users from a data source (e.g., database)
    public Landlords(IEnumerable<Landlord> landlords)
    {
        _landlords = landlords.ToList(); // convert to list for easy management
    }

    // retrieve all users
    public List<Landlord> GetAll()
    {
        return _landlords;
    }
}
