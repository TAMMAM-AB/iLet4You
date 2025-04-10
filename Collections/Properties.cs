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

    public Property FindById(int id)
    {
        return _properties.FirstOrDefault(p => p.PropertyId == id);
    }

    public List<Maintenance>? FindMaintenancesFromId(int id)
    {
        List<Maintenance> maintenances = new List<Maintenance>();
        Global.Maintenances?.GetAll().ForEach(m =>
        {
            if (m.PropertyId == id)
            {
                maintenances.Add(m);
            }
        });

        return maintenances;
    }

    public List<Rent>? FindRentsFromId(int id)
    {
        List<Rent> rents = new List<Rent>();
        Global.Rents?.GetAll().ForEach(m =>
        {
            if (m.PropertyId == id)
            {
                rents.Add(m);
            }
        });

        return rents;
    }
}