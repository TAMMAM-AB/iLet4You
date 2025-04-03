public class Rents
{
    private readonly List<Rent> _rents = new();

    public Rents(IEnumerable<Rent> rents)
    {
        _rents = rents.ToList();
    }

    public List<Rent> GetAll()
    {
        return _rents;
    }
}
