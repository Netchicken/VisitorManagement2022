using static VisitorManagement.Enum.SweetAlertEnum;

namespace VisitorManagement.Services
{
    public class SweetAlert : ISweetAlert
    {
        /// <summary>
        /// SweetAlert popups  https://sweetalert2.github.io/#download https://sweetalert2.github.io/#input-types
        /// </summary>
        /// <param name="id"></param>
        public string AlertPopup(string title, string message, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString() + "', " +
                "buttons: false, " +
                "timer: '10000'})</script>";


        }

        public string AlertCancel(string title, string message, string buttonText, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString() + "', " +
                "button: '" + buttonText + "', " +
                "timer: '5000'})</script>";

        }
        public string AlertOptions(string title, string message, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString() + "', " +
               "showCancelButton: '" + true + "', " +
                "confirmButtonColor:  '#3085d6' , " +
                "cancelButtonColor:  '#d33' , " +
                "confirmButtonText: 'Yes, delete it!' , " +
  "}).then((result) => {if (result.isConfirmed) {Swal.fire('Deleted!','Your file has been deleted.','success') }})</script>";


        }


        public string AlertPopupWithImage(string title, string message, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString() + "', " +
                "imageUrl: '" + "/images/logo.png" + "', " +
                "imageWidth: '" + 200 + "', " +
                "imageHeight: '" + 200 + "', " +
                "buttons: false, " +
                "timer: '5000'})</script>";


        }
    }
}
