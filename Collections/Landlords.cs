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
}
