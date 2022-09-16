using Microsoft.AspNetCore.Mvc;

using System.Xml.Linq;

using static VisitorManagement.Enum.SweetAlertEnum;

namespace VisitorManagement.Controllers
{
    //https://www.linkedin.com/pulse/sweetalert-notification-aspnet-mvc-core-adeyinka-oluwaseun/
    public abstract class SweetAlertBaseController : Controller
    {
        public void Alert( string message, NotificationType notificationType)
        {
            var msg = "swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "";


            var msg2 = "Swal.fire({ title: 'Error!', text: '"+ message + "', icon: '" + notificationType.ToString().ToUpper() + "',  timer: '2000'})";

           


            TempData["notification"] = msg2;
        }


            
        /// <summary>
        /// Sets the information for the system notification.
        /// </summary>
        /// <param name="message">The message to display to the user.</param>
        /// <param name="notifyType">The type of notification to display to the user: Success, Error or Warning.</param>
        public void Message(string message, NotificationType notifyType)
        {
            TempData["Notification2"] = message;

            switch (notifyType)
            {
                case NotificationType.success:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;
                case NotificationType.error:
                    TempData["NotificationCSS"] = "alert-box errors";
                    break;
                case NotificationType.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;

                case NotificationType.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }



    }
}
