public class Landlords
{
    private readonly List<Landlord> _landlords = new();

    public Landlords(IEnumerable<Landlord> landlords)
    {
        _landlords = landlords.ToList();
    }

    public List<Landlord> GetAll()
    {
        return _landlords;
    }

    public Landlord FindById(int id)
    {
        return _landlords.FirstOrDefault(l => l.LandlordId == id);
    }

    public List<Property>? FindPropertiesFromId(int id)
    {
        List<Property> properties = new List<Property>();
        Global.Properties?.GetAll().ForEach(p =>
        {
            if (p.LandlordId == id)
            {
                properties.Add(p);
            }
        });

        return properties;
    }
}
