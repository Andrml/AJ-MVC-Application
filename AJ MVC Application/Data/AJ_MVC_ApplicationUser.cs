using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AJ_MVC_Application.Data;

// Add profile data for application users by adding properties to the AJ_MVC_ApplicationUser class
public class AJ_MVC_ApplicationUser : IdentityUser
{
    public string UserID { get; set; }
}
