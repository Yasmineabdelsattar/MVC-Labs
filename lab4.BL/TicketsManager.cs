using lab4.BL.ViewModels;
using lab4.DAL.Models;
using lab4.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.BL;

public class TicketsManager: ITicketsManager
{
    private readonly ITicketsRepo _ticketsRepo;

    public TicketsManager(ITicketsRepo ticketsRepo)
    {
        _ticketsRepo = ticketsRepo;
    }

    public List<TicketReadVM> GetAll()
    {
        var developersFromDB = _ticketsRepo.GetAll();
        return developersFromDB.Select(d => new TicketReadVM(d.Id, d.Title, d.Description, d.Severity))
            .ToList();
    }

    public TicketReadVM? Get(int id)
    {
        var ticketFromDB = _ticketsRepo.Get(id);
        if (ticketFromDB == null)
        {
            return null;
        }
        return new TicketReadVM(ticketFromDB.Id, ticketFromDB.Title, ticketFromDB.Description, ticketFromDB.Severity);
    }

    public void Add(TicketAddVM ticketVM)
    {
        var ticket = new Ticket
        {
            Title = ticketVM.Title,
            Description = ticketVM.Description,
            Severity = ticketVM.Severity
        };

        _ticketsRepo.Add(ticket);
        _ticketsRepo.SaveChanges();
    }

    public void Edit(TicketEditVM ticketVM)
    {
        var ticketToEdit = _ticketsRepo.Get(ticketVM.Id);

        ticketToEdit.Id = ticketVM.Id;
        ticketToEdit.Title = ticketVM.Title;
        ticketToEdit.Description = ticketVM.Description;
        ticketToEdit.Severity = ticketVM.Severity;

        _ticketsRepo.SaveChanges();
    }

    public void Delete(TicketEditVM ticketVM)
    {
        _ticketsRepo.Delete(ticketVM.Id);
        _ticketsRepo.SaveChanges();

    }

    public int GetRepoHashCode()
    {
        return _ticketsRepo.GetHashCode();
    }

}
