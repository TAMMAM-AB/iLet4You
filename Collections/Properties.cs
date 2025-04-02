public class Properties // collection class
{
    private readonly List<Property> _properties = new(); // stores user records

    // load users from a data source (e.g., database)
    public Properties(IEnumerable<Property> properties)
    {
        _properties = properties.ToList(); // convert to list for easy management
    }

    // retrieve all users
    public List<Property> GetAll()
    {
        return _properties;
    }
}
