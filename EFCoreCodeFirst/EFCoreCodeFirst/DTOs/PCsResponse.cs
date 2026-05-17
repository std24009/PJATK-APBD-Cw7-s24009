namespace EFCoreCodeFirst.DTOs;

public record PCsAllResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);