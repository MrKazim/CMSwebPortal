using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.IRepository
{
    public interface ISendgridEmailRepository
    {
        Task<bool> SendEmail(string name,string email,string message);
    }
}
