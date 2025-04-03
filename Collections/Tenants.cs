public class Tenants
{
    private readonly List<Tenant> _tenants = new();

    public Tenants(IEnumerable<Tenant> tenants)
    {
        _tenants = tenants.ToList();
    }

    public List<Tenant> GetAll()
    {
        return _tenants;
    }
}
