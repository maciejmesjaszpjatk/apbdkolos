using KolokwiumAPBD.Data;
using KolokwiumAPBD.DTOs;
using KolokwiumAPBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WashingMachinesController : Controller
{
    private readonly AppDbContext _context;
    public WashingMachinesController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateWashingMachine([FromBody] CreateWashingMachineRequestDto request)
    {
        var serialNumber = request.WashingMachine.SerialNumber;
        if (await _context.WashingMachines.AnyAsync(wm => wm.SerialNumber == serialNumber))
        {
            return BadRequest($"Washing machine with serial number '{serialNumber}' already exists! Be more original.");
        }
        
        foreach (var prog in request.AvailablePrograms)
        {
            if (!await _context.Programs.AnyAsync(p => p.Name == prog.ProgramName))
            {
                return BadRequest($"Program with name '{prog.ProgramName}' does not exist. Use one that already exists.");
            }
        }
        
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // tworzenie pralki first
            var newWashingMachine = new WashingMachine
            {
                MaxWeight = request.WashingMachine.MaxWeight,
                SerialNumber = request.WashingMachine.SerialNumber
            };
            _context.WashingMachines.Add(newWashingMachine);
            await _context.SaveChangesAsync(); // zapis zeby dostac id

            // zapisuje teraz kazdy program
            foreach (var progDto in request.AvailablePrograms)
            {
                var programEntity = await _context.Programs.FirstAsync(p => p.Name == progDto.ProgramName);
                var newAvailableProgram = new AvailableProgram
                {
                    WashingMachineId = newWashingMachine.WashingMachineId,
                    ProgramId = programEntity.ProgramId,
                    Price = progDto.Price
                };
                _context.AvailablePrograms.Add(newAvailableProgram);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return StatusCode(201, new { message = "Washing machine created successfully." });
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, "Mamy lipe.");
        }
    }
}