using static VisitorManagement.Enum.SweetAlertEnum;

namespace VisitorManagement.Operations
{
    public class SweetAlert : ISweetAlert
    {
        public string Alert(string title, string message, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ title: '" + title + "', text: '" + message + "', icon: '" + notificationType.ToString().ToUpper() + "',  timer: '5000'})</script>";

            // TempData["notification"] = msg2;
        }

    }
}
