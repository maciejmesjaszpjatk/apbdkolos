using System.ComponentModel.DataAnnotations;

namespace KolokwiumAPBD.DTOs;

public class AvailableProgramForCreationDto
{
    [Required]
    public string ProgramName { get; set; }

    [Required]
    [Range(0, 25, ErrorMessage = "Cena danego programu nie moze przekraczac 2!!")]
    public decimal Price { get; set; }
}