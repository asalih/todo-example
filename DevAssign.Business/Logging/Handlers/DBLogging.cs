using DevAssign.Data.Contracts;
using DevAssign.Data.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssign.Business.Logging.Handlers
{
    internal class DBLogging : ILogging
    {
        public Task Log(Exception ex)
        {
            return this.Log(new Data.Model.Log() { Message = ex.ToString(), CreateDate = DateTime.Now, Type = LogType.Exception });
        }

        public Task Log(string msg)
        {
            return this.Log(new Data.Model.Log() { Message = msg, CreateDate = DateTime.Now, Type = LogType.Info });
        }

        private Task Log(Data.Model.Log log)
        {
            TaskFactory factory = new TaskFactory();
            try
            {
                return factory.StartNew(() =>
                {
                    var unitOfWork = ContainerManager.Container.Resolve<IUnitOfWork>();
                    var logRepo = unitOfWork.GetRepository<Data.Model.Log>();
                    logRepo.Add(log);

                    unitOfWork.SaveChanges();
                    unitOfWork.Dispose();
                });
            }
            catch (Exception)
            { return factory.StartNew(() => { }); }

        }
    }
}
