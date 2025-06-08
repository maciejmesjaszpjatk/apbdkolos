using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD.Models;

[Table("Available_Program")]
public class AvailableProgram
{
    [Key]
    public int AvailableProgramId { get; set; }
    
    [ForeignKey(nameof(WashingMachine))]
    public int WashingMachineId { get; set; }
    public WashingMachine WashingMachine { get; set; }
    
    [ForeignKey(nameof(WashingProgram))]
    public int ProgramId { get; set; }
    public WashingProgram Program { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = new List<PurchaseHistory>();
}