using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Magacin.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Magacioner class
public class Magacioner : IdentityUser
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string FullName => $"{Name} {Surname}";
    public string ClearTextPassword { get; set; } = string.Empty;
}

