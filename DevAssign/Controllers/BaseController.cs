using DevAssign.Business;
using DevAssign.Data.Context;
using DevAssign.Data.Contracts;
using DevAssign.Data.Model;
using DevAssign.Data.UnitOfWork;
using System.Data.Entity;
using System.Web.Mvc;

namespace DevAssign.Controllers
{
    public class BaseController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public User SessionUser
        {
            get
            {
                return Session[Consts.SESSION_USER_KEY] as User;
            }
            set
            {
                Session[Consts.SESSION_USER_KEY] = value as User;
            }
        }
        public BaseController()
        {
            this.UnitOfWork = ContainerManager.Container.Resolve<IUnitOfWork>();
        }

        protected override void Dispose(bool disposing)
        {
            UnitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}