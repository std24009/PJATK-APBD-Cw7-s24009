namespace EFCoreCodeFirst.DTOs;

public record PCsDetailsResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PCComponentDetailsResponse> Components
    );