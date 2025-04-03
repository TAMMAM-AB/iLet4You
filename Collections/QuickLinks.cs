public class QuickLinks
{
    private readonly List<QuickLink> _quickLinks = new();

    public QuickLinks(IEnumerable<QuickLink> quickLinks)
    {
        _quickLinks = quickLinks.ToList();
    }

    public List<QuickLink> GetAll()
    {
        return _quickLinks;
    }
}
