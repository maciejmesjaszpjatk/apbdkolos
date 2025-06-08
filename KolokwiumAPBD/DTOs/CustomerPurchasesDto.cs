namespace KolokwiumAPBD.DTOs;

public class CustomerPurchasesDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public IEnumerable<PurchaseDto> Purchases { get; set; }
}