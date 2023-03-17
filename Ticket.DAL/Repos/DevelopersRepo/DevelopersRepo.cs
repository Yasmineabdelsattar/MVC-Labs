using Lab5.DAL.Context;
using Lab5.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.DAL.Repos.DevelopersRepo;

public class DevelopersRepo: IDevelopersRepo
{
    private readonly TicketContext _coontext;

    public DevelopersRepo(TicketContext coontext)
    {
        _coontext = coontext;
    }

    public IQueryable<Developer> GetAll()
    {
        return _coontext.Set<Developer>();
    }
}
