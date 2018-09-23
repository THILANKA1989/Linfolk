using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Services
{
    public interface IMailService
    {
        void SendMessage(String To, String Subject, String Body);
    }
}
