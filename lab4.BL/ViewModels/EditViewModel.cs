using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab4.DAL.Models;


namespace lab4.BL.ViewModels;

public record TicketEditVM {
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public Severity Severity { get; init; } 
}

