public readonly record struct Rent(
    int RentId,
    int? TenantId,
    DateTime DueDate,
    DateTime? DateReceived,
    int RentAmount,
    int RentAmountPaid,
    string? Notes
);