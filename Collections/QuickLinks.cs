public class QuickLinks // collection class
{
    private readonly List<QuickLink> _quickLinks = new(); // stores user records

    // load users from a data source (e.g., database)
    public QuickLinks(IEnumerable<QuickLink> quickLinks)
    {
        _quickLinks = quickLinks.ToList(); // convert to list for easy management
    }

    // retrieve all users
    public List<QuickLink> GetAll()
    {
        return _quickLinks;
    }
}
