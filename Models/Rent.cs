public readonly record struct Rent(
    int RentId,
    DateTime DueDate,
    DateTime? DateReceived,
    int RentAmount,
    int RentAmountPaid,
    string? Notes
);