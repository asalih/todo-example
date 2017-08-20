using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAssign.Data.Model;
using System.Net.Mail;
using System.Net;
using System.Configuration;

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
                    var fromAddress = new MailAddress(ConfigurationManager.AppSettings["senderMail"], "Reminder");
                    var toAddress = new MailAddress(task.ToDo.User.Email, task.ToDo.User.FullName);

                    string fromPassword = ConfigurationManager.AppSettings["senderMailPassword"];
                    string subject = "Reminder";
                    string body = string.Format("Reminder for: {0}", task.TaskBody);

                    var smtp = new SmtpClient
                    {
                        Host = ConfigurationManager.AppSettings["senderSmtp"],
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
