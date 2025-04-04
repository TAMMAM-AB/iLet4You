public readonly record struct Rent(
    int RentId,
    int? TenantId,
    int? PropertyId,
    DateTime DueDate,
    DateTime? DateReceived,
    double RentAmount,
    double RentAmountPaid,
    string? Notes
);