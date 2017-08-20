using DevAssign.Business.Notifications;
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
                using (DevAssign.Data.UnitOfWork.EFUnitOfWork unitOfWork = new Data.UnitOfWork.EFUnitOfWork(new Data.Context.EFDataContext()))
                {
                    new NotificationManager().NotifyUsers(unitOfWork).Wait();
                }

            }, null, 0, period);
        }

    }
}