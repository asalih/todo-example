using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssign.Business.Logging
{
    public interface ILogging
    {
        System.Threading.Tasks.Task Log(Exception ex);
        System.Threading.Tasks.Task Log(string msg);
    }
}
