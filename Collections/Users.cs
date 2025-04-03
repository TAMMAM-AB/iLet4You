public class Users // collection class
{
    private readonly List<User> _users = new(); // stores user records

    // load users from server database
    public Users(IEnumerable<User> users)
    {
        _users = users.ToList(); // convert to list for easy management
    }

    // retrieve all users
    public List<User> GetAll()
    {
        return _users;
    }

    // find user by username
    public User? FindByName(string username)
    {
        return _users.FirstOrDefault(u => u.Username == username);
    }

    // check if a user exists
    public bool Exists(string username)
    {
        return _users.Any(u => u.Username == username);
    }
}
