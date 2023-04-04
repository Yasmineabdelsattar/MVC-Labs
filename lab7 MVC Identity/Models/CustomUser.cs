using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab7_MVC_Identity.Models;

public class CustomUser: IdentityUser
{
    public DateTime DateOfBirth { get; set; }
}
