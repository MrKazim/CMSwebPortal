using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.Models.Response
{
    public class LoginResponse:Status
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? Expiration { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
    }
}
