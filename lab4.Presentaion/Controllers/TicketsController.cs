using Microsoft.AspNetCore.Mvc;
using lab4.BL;
using lab4.BL.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace lab4.Presentaion.Controllers;

public class TicketsController : Controller
{
    private readonly ITicketsManager _ticketsManager;

    public TicketsController(ITicketsManager ticketsManager)
    {
        _ticketsManager = ticketsManager;
    }

    public IActionResult Index()
    {
        return View(_ticketsManager.GetAll());
    }

    public IActionResult Details(int id)
    {
        var ticket = _ticketsManager.Get(id);
        if (ticket is null)
        {
            View("NotFoundTicket");
        }
        return View(ticket);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(TicketAddVM ticket)
    {
        _ticketsManager.Add(ticket);
        return RedirectToAction(nameof(Index));
    }

    ////////////edit///////////
   
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ticketToEdit = _ticketsManager.Get(id);
        if(ticketToEdit is null) { View("NotFoundTicket"); }
        var ticketEditVM = new TicketEditVM
        {
            Id = ticketToEdit.Id,
            Title = ticketToEdit.Title,
            Description = ticketToEdit.Description,
            Severity = ticketToEdit.Severity
        };

        return View(ticketEditVM);
    }

    [HttpPost]
    public IActionResult Edit(TicketEditVM ticketVM)
    {
        _ticketsManager.Edit(ticketVM);
        return RedirectToAction(nameof(Index));
    }

   ////////////delete////

    [HttpPost]
    public IActionResult Delete(TicketEditVM ticketVM)
    {
        _ticketsManager.Delete(ticketVM);
        return RedirectToAction(nameof(Index));
    }



    ////////////////////////////////////////////////////////////////////

    #region Images

    //[HttpGet]
    //public IActionResult AddImage()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public IActionResult AddImage(AddImageVM vm)
    //{
    //    if (vm.Image is null)
    //    {
    //        ModelState.AddModelError("", "Image is not found");
    //        return View();
    //    }
    //    if (vm.Image.Length > 1000_000)
    //    {
    //        ModelState.AddModelError("", "Image size exceeded the limit");
    //        return View();
    //    }
    //    var allowedExtensions = new string[] { ".png", ".svg" };
    //    var sentExtension = Path.GetExtension(vm.Image.FileName).ToLower();
    //    if (!allowedExtensions.Contains(sentExtension))
    //    {
    //        ModelState.AddModelError("", "Image extension is not valid");
    //        return View();
    //    }
    //    string newName = $"{Guid.NewGuid()}{sentExtension}";
    //    string fullPath = @$"C:\Users\Al Badr\source\repos\lab1MVC\lab4.Presentaion\wwwroot\Images{newName}";

    //    using (var stream = System.IO.File.Create(fullPath))
    //    {
    //        vm.Image.CopyTo(stream);
    //    }
      
    //    return RedirectToAction(nameof(Index));
    //}

    #endregion

    #region fields

    static readonly List<string> titles = new List<string>
    {
        "in","id","dicta","eius","assumenda","ex","velit","voluptas","recusandae","qui","autem","totam","enim",
        "natus","et","aut","etnn","iusto","facere","recusandae"
    };
    #endregion

    #region Validation

    public IActionResult ValidateTitle(string title)
    {
        if (titles.Contains(title))
        {
            return Json($"{title} is taken");
        }
        return Json(true);
    }

    #endregion

}
