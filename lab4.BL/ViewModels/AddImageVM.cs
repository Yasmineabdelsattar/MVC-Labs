using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.BL.ViewModels;

public record AddImageVM(int Id, IFormFile? Image);

