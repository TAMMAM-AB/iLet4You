public readonly record struct User
{ // readonly record struct for immutability
    public string Username { get; }
    public string Password { get; } // hashed?

    public User() // CONTINUE
    {

    }
}