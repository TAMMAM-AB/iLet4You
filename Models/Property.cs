public readonly record struct Property(
    int PropertyId,
    int LandlordId,
    int? TenantId,
    string? HouseNo,
    string AddressLine1,
    string City,
    string PostCode,
    double RentAmount,
    DateTime? GasCertExpiry,
    DateTime? EPCExpiry,
    DateTime? EICRExpiry,
    string? EPCRating,
    string? Notes
);