namespace KolokwiumAPBD.DTOs;

public class PurchaseDto
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public decimal Price { get; set; }
    public WashingMachineInfoDto WashingMachine { get; set; }
    public ProgramInfoDto Program { get; set; }
}