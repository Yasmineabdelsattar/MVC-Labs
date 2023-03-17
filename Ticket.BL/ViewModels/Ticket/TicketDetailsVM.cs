using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.BL.ViewModels.Ticket;

public record TicketDetailsVM(
    int Id,
    string Description,
    [Display(Name = "Department's Name")]
    string DepartmentName,
    int DevelopersCount);
