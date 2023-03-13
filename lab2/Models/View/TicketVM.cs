using lab2.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lab2.Models.View;

public record TicketVM
{
    [Display(Name = "Is Closed")]
    public bool IsClosed { get; init; }
    public Severitys Severity { get; init; }
    public string Description { get; init; } = string.Empty;


}
