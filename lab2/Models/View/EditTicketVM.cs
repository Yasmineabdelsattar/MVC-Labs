using lab2.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lab2.Models.View;

public record EditTicketVM
{
    public Guid Id { get; set; }
    [Display(Name = "Is Closed")]
    public bool IsClosed { get; init; }
    public Severitys Severity { get; init; }
    public string Description { get; init; } = string.Empty;

    [Display(Name = "Department")]
    public Guid DepartmentId { get; init; }

    [Display(Name = "Assignees")]
    public List<Guid> DevelopersIds { get; init; } = new();
}
