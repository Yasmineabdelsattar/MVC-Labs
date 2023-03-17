using Lab5.DAL.Context;
using Lab5.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.DAL.Repos.DepartmentsRepo;

public class DepartmentsRepo: IDepartmentsRepo
{
    private readonly TicketContext _context;

    public DepartmentsRepo(TicketContext context)
    {
        _context = context;
    }

    public IEnumerable<Department> GetAll()
    {
        return _context.Set<Department>();
    }
}
