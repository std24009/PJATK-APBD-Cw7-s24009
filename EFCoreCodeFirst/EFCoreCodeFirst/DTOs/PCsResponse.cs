namespace EFCoreCodeFirst.DTOs;

public record PCsResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);