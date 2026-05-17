namespace EFCoreCodeFirst.DTOs;

public record ComponentDetailsResponse(
    string Code,
    string Name,
    string Description,
    ManufacturerDetailsResponse Manufacturer,
    TypeDetailsResponse Type
    );