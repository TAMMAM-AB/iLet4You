public readonly record struct Rent(
    int RentId,
    int? TenantId,
    int? PropertyId,
    DateTime DueDate,
    DateTime? DateReceived,
    int RentAmount,
    int RentAmountPaid,
    string? Notes
);