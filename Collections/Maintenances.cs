public class Maintenances // collection class
{
    private readonly List<Maintenance> _maintenances = new(); // stores user records

    // load users from a data source (e.g., database)
    public Maintenances(IEnumerable<Maintenance> maintenances)
    {
        _maintenances = maintenances.ToList(); // convert to list for easy management
    }

    // retrieve all users
    public List<Maintenance> GetAll()
    {
        return _maintenances;
    }
}
