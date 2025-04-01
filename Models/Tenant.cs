public readonly record struct Tenant( // modern format, immutable
    int TenantId,                    // records always generate public properties
    string FirstName,               // so these are all public
    string LastName,
    string HouseNo,
    string AddressLine1,
    string City,
    string PostCode,
    string? PhoneNumber,
    string? Email,
    string? Notes
);