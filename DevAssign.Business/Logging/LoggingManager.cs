using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssign.Business.Logging
{
    public class LoggingManager
    {
        public static ILogging GetLogger()
        {
            return ContainerManager.Container.Resolve<ILogging>();
        }
    }
}
