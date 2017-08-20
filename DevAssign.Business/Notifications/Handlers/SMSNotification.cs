using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAssign.Data.Model;

namespace DevAssign.Business.Notifications.Handlers
{
    public class SMSNotification : INotification
    {
        public System.Threading.Tasks.Task NotifyUser(Data.Model.Task task)
        {
            return System.Threading.Tasks.Task.Run(() => {

            });
        }
    }
}
