using Lab5.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.DAL.Repos.TicketsRepo;

public interface ITicketsRepo
{
    Ticket? GetTicketWithDevelopersAndDepartment(int id);
    Ticket? GetTicketWithDevelopers(int id);
    void Save();
    void Update(Ticket ticket);
}
