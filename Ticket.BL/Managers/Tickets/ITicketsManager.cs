using Lab5.BL.ViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.BL.Managers.Tickets;

public interface ITicketsManager
{
    TicketDetailsVM? GetTicketDetails(int id);
    TicketEditVM? GetForEdit(int id);
    void Update(TicketEditVM ticketVM);
}
