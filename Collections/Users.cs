using System.Collections.Generic;
using System.Linq;

public class Users // collection class
{
    private readonly List<User> _users = new(); // stores user records

    // load users from a data source (e.g., database)
    public Users(IEnumerable<User> users)
    {
        _users = users.ToList(); // convert to List for easy management
    }

    // retrieve all users
    public List<User> GetAllUsers()
    {
        return _users;
    }

    // find user by username
    public User? FindByUsername(string username)
    {
        return _users.FirstOrDefault(u => u.Username == username);
    }

    // check if a user exists
    public bool UserExists(string username)
    {
        return _users.Any(u => u.Username == username);
    }
}
