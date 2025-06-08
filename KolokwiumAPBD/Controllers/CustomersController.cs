using KolokwiumAPBD.Data;
using KolokwiumAPBD.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : Controller
{
    
    private readonly AppDbContext _context;
    public CustomersController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetPurchasesForCustomer(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        var purchases = await _context.PurchaseHistories
            .Where(ph => ph.CustomerId == id)
            .Include(ph => ph.AvailableProgram) 
            .ThenInclude(ap => ap.WashingMachine) // dolaczam pralke z dostepnych programow
            .Include(ph => ph.AvailableProgram) 
            .ThenInclude(ap => ap.Program) 
            .Select(ph => new PurchaseDto
            {
                Date = ph.PurchaseDate,
                Rating = ph.Rating,
                Price = ph.AvailableProgram.Price,
                WashingMachine = new WashingMachineInfoDto
                {
                    Serial = ph.AvailableProgram.WashingMachine.SerialNumber,
                    MaxWeight = ph.AvailableProgram.WashingMachine.MaxWeight
                },
                Program = new ProgramInfoDto
                {
                    Name = ph.AvailableProgram.Program.Name,
                    Duration = ph.AvailableProgram.Program.DurationMinutes
                }
            })
            .ToListAsync();

        var result = new CustomerPurchasesDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = purchases
        };

        return Ok(result);
        
    }
}