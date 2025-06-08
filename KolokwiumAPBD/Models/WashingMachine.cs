using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD.Models;

[Table("WashingMachines")]
public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal MaxWeight { get; set; }
    [Required]
    [MaxLength(100)]
    public string SerialNumber { get; set; }
    
    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = new List<AvailableProgram>();

    
}