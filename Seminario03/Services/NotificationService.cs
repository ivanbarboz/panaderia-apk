using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;

namespace Seminario03.Services
{
    public class NotificationService
    {
        public static void SendNotification(string title, string message)
        {
            var notification = new NotificationRequest
            {
                NotificationId = 100,
                Title = title,
                Description = message,
                ReturningData = "Dummy data",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5)
                }
            };

            LocalNotificationCenter.Current.Show(notification);
        }
    }
}
