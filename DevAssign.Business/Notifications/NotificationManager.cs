using DevAssign.Data.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevAssign.Business.Notifications
{
    public class NotificationManager
    {
        private INotification[] notificationObjects;
        public NotificationManager()
        {
            notificationObjects = ContainerManager.Container.ResolveAll<INotification>();
        }
        public Task NotifyUsers(IUnitOfWork unitOfWorks)
        {
            TaskFactory factory = new TaskFactory();
            try
            {
                if (notificationObjects == null)
                {
                    return null;
                }

                return factory.StartNew(() =>
                {
                    var reminderRepo = unitOfWorks.GetRepository<DevAssign.Data.Model.Reminder>();
                    var reminders = reminderRepo.GetAll(reminder => reminder.When < DateTime.Now, "Task,Task.ToDo.User").Take(Consts.NOTIFY_RANGE).ToList();

                    if (reminders != null && reminders.Count > 0)
                    {
                        foreach (var item in notificationObjects)
                        {
                            foreach (var reminder in reminders)
                            {
                                item.NotifyUser(reminder.Task);
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                return factory.StartNew(() => { Logging.LoggingManager.GetLogger().Log(ex); });
            }





        }
    }
}
