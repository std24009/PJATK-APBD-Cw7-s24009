namespace EFCoreCodeFirst.Models;

public class ComponentManufacturers
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateOnly FoundationDate { get; set; }
}