using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAssign.Data.Model;
using System.Net.Mail;
using System.Net;

namespace DevAssign.Business.Notifications.Handlers
{
    public class EmailNotification : INotification
    {
        public System.Threading.Tasks.Task NotifyUser(Data.Model.Task task)
        {
            return System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    var fromAddress = new MailAddress("ahmet.salih@gmail.com", "Ahmet Salih");
                    var toAddress = new MailAddress(task.ToDo.User.Email, task.ToDo.User.FullName);

                    const string fromPassword = "****";
                    const string subject = "Reminder";
                    string body = string.Format("Reminder for: {0}", task.TaskBody);

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    Logging.LoggingManager.GetLogger().Log(ex);
                }

            });
        }
    }
}
