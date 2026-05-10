using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.Models;

[Table("PCs")]
public class PCs
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(5)]
    public float Weight { get; set; }
    
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public IEnumerable<PCComponents> PcComponents { get; set; } = [];
}