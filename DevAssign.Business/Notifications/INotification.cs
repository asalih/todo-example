using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssign.Business.Notifications
{
    public interface INotification
    {
        Task NotifyUser(DevAssign.Data.Model.Task task);
    }
}
