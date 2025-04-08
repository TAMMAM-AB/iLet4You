public class Maintenances
{
    private readonly List<Maintenance> _maintenances = new();

    public Maintenances(IEnumerable<Maintenance> maintenances)
    {
        _maintenances = maintenances.ToList();
    }

    public List<Maintenance> GetAll()
    {
        return _maintenances;
    }
}