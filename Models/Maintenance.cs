public readonly record struct Maintenance(
    int MaintenanceId,
    int PropertyId,
    string Description,
    string Status,
    DateTime DateReported,
    DateTime? DateCompleted
);