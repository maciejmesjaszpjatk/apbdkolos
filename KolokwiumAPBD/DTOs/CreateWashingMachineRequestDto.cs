using System.ComponentModel.DataAnnotations;

namespace KolokwiumAPBD.DTOs;

public class CreateWashingMachineRequestDto
{
    [Required]
    public WashingMachineForCreationDto WashingMachine { get; set; }
    [Required]
    public IEnumerable<AvailableProgramForCreationDto> AvailablePrograms { get; set; }
}