﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.DAL.Models;

public class Ticket
{
    public int Id { get; set; }

    [Required]
    [Remote(action: "ValidateTitle", controller: "Tickets")]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public Severity Severity { get; set; }
}
