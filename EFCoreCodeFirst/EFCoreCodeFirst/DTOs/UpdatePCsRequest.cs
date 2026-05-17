using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.DTOs;

public record UpdatePCsRequest(
    [MaxLength(50)] string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
    );