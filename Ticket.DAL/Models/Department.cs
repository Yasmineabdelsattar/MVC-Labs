using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab5.DAL.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    #region Initial List

    //private static List<Department> _departments = JsonSerializer.Deserialize<List<Department>>
    //    ("""[{"Id":"1","Name":"Automotive \u0026 Baby"},{"Id":"2","Name":"Beauty \u0026 Health"},{"Id":"3","Name":"Electronics"}]""") ?? new();

    #endregion

    public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    //public static List<Department> GetDepartments() => _departments;
}
