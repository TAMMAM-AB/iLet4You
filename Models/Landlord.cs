public readonly record struct Landlord(
    int LandlordId,
    string FirstName,
    string LastName,
    string Address,
    string? PhoneNumber,
    string? Email,
    string? Notes
);