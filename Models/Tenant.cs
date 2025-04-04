public readonly record struct Tenant(
    int TenantId,
    string FirstName,
    string LastName,
    string? PhoneNumber,
    string? Email,
    string? Notes
);