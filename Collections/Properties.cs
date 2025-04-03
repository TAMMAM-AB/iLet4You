public class Properties
{
    private readonly List<Property> _properties = new();

    public Properties(IEnumerable<Property> properties)
    {
        _properties = properties.ToList();
    }

    public List<Property> GetAll()
    {
        return _properties;
    }
}
