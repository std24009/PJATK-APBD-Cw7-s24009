using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.DTOs;

public record CreatePCsRequest(
    [MaxLength(50)] string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
    );