using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
    }
}
