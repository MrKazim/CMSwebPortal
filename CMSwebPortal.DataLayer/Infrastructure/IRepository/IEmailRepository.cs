using CMSwebPortal.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.IRepository
{
    public interface IEmailRepository
    {
        void SendEmail(Message message);
    }
}
