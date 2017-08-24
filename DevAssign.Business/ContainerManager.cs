using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DevAssign.Business.Logging;
using DevAssign.Business.Logging.Handlers;
using DevAssign.Business.Notifications;
using DevAssign.Business.Notifications.Handlers;
using DevAssign.Data.Context;
using DevAssign.Data.Contracts;
using DevAssign.Data.UnitOfWork;
using System.Data.Entity;

namespace DevAssign.Business
{
    public static class ContainerManager
    {
        public static IWindsorContainer Container = null;

        static ContainerManager()
        {
            Container = new WindsorContainer();
            Container.Register(
                Component.For<INotification>().ImplementedBy<EmailNotification>(),
                //Component.For<INotification>().ImplementedBy<SMSNotification>(),
                Component.For<ILogging>().ImplementedBy<DBLogging>(),
                Component.For<DbContext>().ImplementedBy<EFDataContext>().Named("dataContext").LifestyleTransient(),
                Component.For<IUnitOfWork>().ImplementedBy<EFUnitOfWork>().Named("unitOfWork").LifestyleTransient()
            );
        }
    }
}
