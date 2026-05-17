namespace EFCoreCodeFirst.DTOs;

public record ManufacturerDetailsResponse(
    int Id,
    string Abbreviation,
    string FullName,
    DateOnly FoundationDate
    );