using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab5.DAL.Models;

public class Ticket
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();


    //public Ticket()
    //{
    //    //Id = Guid.NewGuid();
    //}

    //public Ticket(
    //    string description,
    //    Department department,
    //    Developer developer
    //    )

    //{
    //    Description = description;
    //    Department = department;
    //}

    #region Initial List

    //private static List<Ticket> _developers = JsonSerializer.Deserialize<List<Ticket>>
    //    ("""[{"Id":"1","Description":"Cumque unde dolores placeat reprehenderit et porro minima sit.", 
    //    "Department":{"Id":"3","Name":"Electronics"},"Developers":[{"Id":"1","Name":"Freddie"}]},{"Id":
    //    "2","Description":"Qui voluptatem itaque ducimus quibusdam dolores vero sunt.","Department":{"Id":
    //        "1","Name":"Automotive \u0026 Baby"},"Developers":[{"Id":"5","Name":"Geoffrey"},{"Id":"2","Name":
    //        "Sophia"}]},{"Id":"3","Description":"Provident sed tenetur esse quidem debitis aut quisquam illum."
    //    ,"Department":{"Id":"3","Name":"Electronics"},"Developers":[{"Id":"3","Name":"Angela"},{"Id":"5","Name":"Geoffrey"}]},{"Id":"4","Description":"Ab atque alias et maiores dicta rerum officiis perferendis.","Department":{"Id":"1","Name":"Automotive \u0026 Baby"},"Developers":[{"Id":"3","Name":"Angela"}]}]""") ?? new();
    //private static readonly List<Ticket> _developers= new List<Ticket>();
    #endregion

    //public static List<Ticket> GetTickets() => _developers;


}
