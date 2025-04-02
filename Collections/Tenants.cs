public class Tenants // collection class
{
    private readonly List<Tenant> _tenants = new(); // stores user records

    // load users from a data source (e.g., database)
    public Tenants(IEnumerable<Tenant> tenants)
    {
        _tenants = tenants.ToList(); // convert to list for easy management
    }

    // retrieve all users
    public List<Tenant> GetAll()
    {
        return _tenants;
    }
}
