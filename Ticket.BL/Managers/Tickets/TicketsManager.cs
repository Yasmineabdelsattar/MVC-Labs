using Lab5.BL.ViewModels.Ticket;
using Lab5.DAL.Models;
using Lab5.DAL.Repos.DevelopersRepo;
using Lab5.DAL.Repos.TicketsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.BL.Managers.Tickets;

public class TicketsManager: ITicketsManager
{
    private readonly ITicketsRepo _ticketsRepo;
    private readonly IDevelopersRepo _developersRepo;

    public TicketsManager(ITicketsRepo ticketsRepo,
        IDevelopersRepo developersRepo)
    {
        _ticketsRepo = ticketsRepo;
        _developersRepo = developersRepo;
    }

    public TicketEditVM? GetForEdit(int id)
    {
        Ticket? ticketFromDb = _ticketsRepo.GetTicketWithDevelopers(id);
        if (ticketFromDb is null)
        {
            return null;
        }
        return new TicketEditVM(Id: ticketFromDb.Id,
            Description: ticketFromDb.Description,
            DepartmentId: ticketFromDb.DepartmentId,
            DevelopersIds: ticketFromDb.Developers.Select(i => i.Id).ToArray());
    }

    public TicketDetailsVM? GetTicketDetails(int id)
    {
        Ticket? ticketFromDb = _ticketsRepo.GetTicketWithDevelopersAndDepartment(id);
        if (ticketFromDb is null)
        {
            return null;
        }

        return new TicketDetailsVM(
            Id: ticketFromDb.Id,
            Description: ticketFromDb.Description,
            DepartmentName: ticketFromDb.Department?.Name ?? "",
            DevelopersCount: ticketFromDb.Developers.Count);
    }

    public void Update(TicketEditVM ticketVM)
    {
        Ticket? entityToUpdate = _ticketsRepo.GetTicketWithDevelopers(ticketVM.Id);
        if (entityToUpdate is null)
        {
            return;
        }
        entityToUpdate.Description = ticketVM.Description;
        entityToUpdate.DepartmentId = ticketVM.DepartmentId;
        entityToUpdate.Developers = GetDevelopersByIds(ticketVM.DevelopersIds);
        _ticketsRepo.Update(entityToUpdate);
        _ticketsRepo.Save();
    }

    private ICollection<Developer> GetDevelopersByIds(int[] developersIds)
    {
        var developers = _developersRepo.GetAll();
        return developers.Where(i => developersIds.Contains(i.Id)).ToList();
    }
}
