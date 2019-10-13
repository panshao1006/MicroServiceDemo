using Log.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.API.Interface
{
    public interface ILoggerBusiness
    {
        void AddLog(LogDTO log);
    }
}
