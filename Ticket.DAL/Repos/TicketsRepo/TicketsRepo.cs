using Lab5.DAL.Context;
using Lab5.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.DAL.Repos.TicketsRepo;

public class TicketsRepo: ITicketsRepo
{
    private readonly TicketContext _context;

    public TicketsRepo(TicketContext context)
    {
        _context = context;
    }

    public Ticket? GetTicketWithDevelopers(int id)
    {
        return _context.Set<Ticket>()
            .Include(p => p.Developers)
            .FirstOrDefault(p => p.Id == id);
    }

    public Ticket? GetTicketWithDevelopersAndDepartment(int id)
    {
        return _context.Set<Ticket>()
            .Include(p => p.Department)
            .Include(p => p.Developers)
            .FirstOrDefault(p => p.Id == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    

    public void Update(Ticket ticket)
    {
        
    }


}
