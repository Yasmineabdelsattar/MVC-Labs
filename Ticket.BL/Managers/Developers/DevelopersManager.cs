using Lab5.DAL.Models;
using Lab5.DAL.Repos.DevelopersRepo;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.BL.Managers.Developers;

public class DevelopersManager: IDevelopersManager
{
    private readonly IDevelopersRepo _developersRepo;

    public DevelopersManager(IDevelopersRepo developersRepo)
    {
        _developersRepo = developersRepo;
    }
    public IEnumerable<SelectListItem> GetDevelopersListItems()
    {
        IEnumerable<Developer> developersFromDb = _developersRepo.GetAll();
        return developersFromDb.Select(i => new SelectListItem(i.Name, i.Id.ToString()));
    }
}
