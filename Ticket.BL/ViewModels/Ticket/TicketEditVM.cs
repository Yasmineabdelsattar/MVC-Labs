using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.BL.ViewModels.Ticket;

public record TicketEditVM(
    int Id,
    string Description,
    int DepartmentId,
    int[] DevelopersIds);
