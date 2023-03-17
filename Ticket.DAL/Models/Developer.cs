using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab5.DAL.Models;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    #region Initial List

    //private static List<Developer> _developers = JsonSerializer.Deserialize<List<Developer>>
    //    ("""[{"Id":"1","Name":"Freddie"},{"Id":"2","Name":"Sophia"},{"Id":"3","Name":"Angela"},{"Id":"4","Name":"Jamie"},{"Id":"5","Name":"Geoffrey"}]""") ?? new();

    #endregion

    //public static List<Developer> GetDevelopers() => _developers;
    public ICollection<Ticket> Patients { get; set; } = new HashSet<Ticket>();
}
