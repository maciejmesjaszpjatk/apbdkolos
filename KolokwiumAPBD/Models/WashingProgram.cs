using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD.Models;

[Table("Program")]
public class WashingProgram
{
    [Key]
    public int ProgramId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public int DurationMinutes { get; set; }
    [Required]
    public int TemperatureCelcius { get; set; }
    
    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = new List<AvailableProgram>();

}