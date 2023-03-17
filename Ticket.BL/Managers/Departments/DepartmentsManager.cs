using Lab5.DAL.Repos.DepartmentsRepo;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.BL.Managers.Departments;

public class DepartmentsManager: IDepartmentsManager
{
    private readonly IDepartmentsRepo _departmentsRepo;

    public DepartmentsManager(IDepartmentsRepo departmentsRepo)
    {
        _departmentsRepo = departmentsRepo;
    }

    public IEnumerable<SelectListItem> GetDepartmentsListItems()
    {
        var departmentsFromDb = _departmentsRepo.GetAll();
        return departmentsFromDb.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
    }
}
