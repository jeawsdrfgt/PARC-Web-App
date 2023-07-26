using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PARC_Web_App.Areas.Identity.Data;

// Add profile data for application users by adding properties to the PARC_Web_AppUser class
public class PARC_Web_AppUser : IdentityUser
{
    public string RegistrationNumber { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
   
}

