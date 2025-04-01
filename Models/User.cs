public readonly record struct User(
    string Username,
    string PasswordHash,
    string Role
);