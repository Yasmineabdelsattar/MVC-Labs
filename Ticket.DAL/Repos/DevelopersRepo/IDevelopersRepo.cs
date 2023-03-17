using Lab5.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.DAL.Repos.DevelopersRepo;

public interface IDevelopersRepo
{
    IQueryable<Developer> GetAll();
}
