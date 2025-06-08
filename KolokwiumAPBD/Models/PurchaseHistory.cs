using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumAPBD.Models;

[Table("Purchase_History")]
public class PurchaseHistory
{
    [ForeignKey(nameof(AvailableProgram))]
    public int AvailableProgramId { get; set; }
    public AvailableProgram AvailableProgram { get; set; }

    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public DateTime PurchaseDate { get; set; }
    public int? Rating { get; set; }
}