using System.ComponentModel.DataAnnotations;

namespace KolokwiumAPBD.DTOs;

public class WashingMachineForCreationDto
{
    [Required]
    [Range(8, double.MaxValue, ErrorMessage = "Maksymalna dopuszczalna waga nie moze byc mniejsza niz 8kg!!!!")]
    public decimal MaxWeight { get; set; }

    [Required]
    [MaxLength(100)]
    public string SerialNumber { get; set; }
}