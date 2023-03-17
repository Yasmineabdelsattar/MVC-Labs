using Lab5.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.DAL.Repos.DepartmentsRepo;

public interface IDepartmentsRepo
{
    IEnumerable<Department> GetAll();
}
