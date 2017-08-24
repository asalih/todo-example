using DevAssign.Business;
using DevAssign.Business.Notifications;
using DevAssign.Data.Contracts;
using System.Threading;
using System.Web;

namespace DevAssign
{
    public class TimerConfig
    {
        static Timer t;

        public static void RegisterTimer(int period)
        {
            t = new Timer((state) =>
            {
                
                using (IUnitOfWork unitOfWork = ContainerManager.Container.Resolve<IUnitOfWork>())
                {
                    new NotificationManager().NotifyUsers(unitOfWork).Wait();
                }

            }, null, 0, period);
        }

    }
}