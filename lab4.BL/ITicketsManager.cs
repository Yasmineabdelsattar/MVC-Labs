using lab4.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.BL;

public interface ITicketsManager
{
    List<TicketReadVM> GetAll();
    TicketReadVM? Get(int id);
    void Add(TicketAddVM ticket);
    void Edit(TicketEditVM ticket);
    void Delete(TicketEditVM ticket);
    int GetRepoHashCode();
}
