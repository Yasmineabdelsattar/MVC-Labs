using lab2.Models.Domain;
using lab2.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers;

public class TicketController : Controller
{
    public IActionResult Index()
    {
        var tickets = Ticket.GetTicketsList();
        return View(tickets);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

   
    [HttpPost]
    public IActionResult Add(TicketVM ticketVM)
    {
        var ticketssList = Ticket.GetTicketsList();
        var newTicket = new Ticket
        {
            CreatedDate= DateTime.Now,
            IsClosed=ticketVM.IsClosed,
            Severity=ticketVM.Severity,
            Description=ticketVM.Description,
        };
        ticketssList.Add(newTicket);
        return RedirectToAction(nameof(Index));
    }
}
