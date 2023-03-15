using lab4.DAL.Context;
using lab4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.DAL.Repositories;

public class TicketsRepo: ITicketsRepo
{
    private readonly IssuesContext _context;

    public TicketsRepo(IssuesContext context)
    {
        _context = context;
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _context.Set<Ticket>();
    }

    public Ticket? Get(int id)
    {
        return _context.Set<Ticket>().Find(id);
    }

    public void Add(Ticket ticket)
    {
        _context.Set<Ticket>().Add(ticket);
    }

    public void Update(Ticket ticket)
    {
        _context.Set<Ticket>().Update(ticket);
    }

    public void Delete(int id)
    {
        var ticketToDelete = Get(id);
        if (ticketToDelete != null)
        {
            _context.Set<Ticket>().Remove(ticketToDelete);
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
