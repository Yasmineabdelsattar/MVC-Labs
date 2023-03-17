using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.BL.Managers.Developers;

public interface IDevelopersManager
{
    IEnumerable<SelectListItem> GetDevelopersListItems();
}
