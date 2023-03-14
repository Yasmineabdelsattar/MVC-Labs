using lab2.Models.Domain;
using lab2.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
using System.Linq;

namespace lab2.Controllers;

public class TicketController : Controller
{
    private static readonly List<Ticket> _tickets = new();
    public IActionResult Index()
    {
        var tickets = Ticket.GetTickets();
        return View(_tickets);
    }


    public IActionResult GetDetails(Guid id)
    {
        return View(_tickets);
    }

    [HttpGet]
    public IActionResult Add()
    {
        GetFormDataReady();
        return View();
    }

   
    [HttpPost]
    public IActionResult Add(TicketVM ticketVM)
    {
        var ticketssList = Ticket.GetTickets();

        var developers = Developer.GetDevelopers();
        var selectedDevelopersIds = ticketVM.DevelopersIds;

        var selectedevelopers = developers
            .Where(d => selectedDevelopersIds.Contains(d.Id))
            .ToList();


        Ticket newTicket = new Ticket
        {
            Id = Guid.NewGuid(),
            CreatedDate= DateTime.Now,
            IsClosed=ticketVM.IsClosed,
            Severity=ticketVM.Severity,
            Description=ticketVM.Description,
            Department = Department.GetDepartments().First(c => c.Id == ticketVM.DepartmentId ),
            Developers = selectedevelopers,
        };
        _tickets.Add(newTicket);
        return RedirectToAction(nameof(Index));
    }




    #region Edit
    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        GetFormDataReady();
        var ticketToEdit = _tickets.First(a => a.Id == id);
        var ticketVM = new EditTicketVM
        {
            Id = ticketToEdit.Id,
            Description = ticketToEdit.Description,
            IsClosed = ticketToEdit.IsClosed,
            Severity= ticketToEdit.Severity,
            DepartmentId = ticketToEdit.Department.Id,
            DevelopersIds = ticketToEdit.Developers.Select(d => d.Id).ToList(),
        };

        return View(ticketVM);
    }

    [HttpPost]
    public IActionResult Edit(EditTicketVM ticketVM)
    {
        var selectedDevelopers = GetDevelopersByIds (ticketVM.DevelopersIds);

        var ticketToEdit = _tickets.First(a => a.Id == ticketVM.Id);

        ticketToEdit.Description = ticketVM.Description;
        ticketToEdit.Severity = ticketVM.Severity;
        ticketToEdit.IsClosed = ticketVM.IsClosed;
        ticketToEdit.Department = Department.GetDepartments().First(c => c.Id == ticketVM.DepartmentId);
        ticketToEdit.Developers = selectedDevelopers;

        return RedirectToAction(nameof(Index));
    }

    #endregion



    #region Helpers

    private void GetFormDataReady()
    {
        #region Departments
        var departments = Department.GetDepartments();
        //ViewBag.Countries = countries;

        //var countriesList = countries.Select(MapCountryToItem);
        var departmentsList = departments
            .Select(department => new SelectListItem(department.Name, department.Id.ToString()));

        ViewData["Departments"] = departmentsList;
        #endregion

        #region Developers
        var developers = Developer.GetDevelopers();
        var developersListItems = developers.Select(d => new SelectListItem(d.FirstName, d.Id.ToString()));
        ViewBag.awardsListItems = developersListItems;
        #endregion
    }


    private static List<Developer> GetDevelopersByIds(List<Guid> selectedDevelopersIds)
    {
        var developers = Developer.GetDevelopers();
        var selectedDevelopers = developers
            .Where(d => selectedDevelopersIds.Contains(d.Id))
            .ToList();
        return selectedDevelopers;
    }


    #endregion

}
