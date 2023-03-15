using lab4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.BL.ViewModels;

public record TicketReadVM(int Id, string Title, string Description, Severity Severity)
{
    public string TitleMarkup => $"<h4> {Title} </h4>";
    public string DescMarkup => $"<h4> {Description} </h4>";

};
