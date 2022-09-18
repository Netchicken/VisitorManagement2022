using static VisitorManagement.Enum.SweetAlertEnum;

namespace VisitorManagement.Operations
{
    public class SweetAlert : ISweetAlert
    {
        /// <summary>
        /// SweetAlert popups  https://sweetalert2.github.io/#download
        /// </summary>
        /// <param name="id"></param>
        public string AlertPopup(string title, string message, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString() + "', " +
                "buttons: false, " +
                "timer: '5000'})</script>";


        }

        public string AlertCancel(string title, string message, string buttonText, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString().ToUpper() + "', " +
                "button: '" + buttonText + "', " +
                "timer: '5000'})</script>";

        }
        public string AlertOptions(string title, string message, string buttonText1, string buttonText2, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString().ToUpper() + "', " +
                //  "buttons: '" [ + buttonText1 + "', '" + buttonText2 + ] + "', " +
                "timer: '5000'})</script>";

        }
        // buttons: ["Oh noez!", "Aww yiss!"],

        public string AlertPopupWithImage(string title, string message, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString() + "', " +
                "imageUrl: '" + "/images/logo.png" +"', "+
                "imageWidth: '" + 200 +"', "+
                "imageHeight: '" + 200 + "', " +
                "buttons: false, " +
                "timer: '5000'})</script>";


        }
    }
}
