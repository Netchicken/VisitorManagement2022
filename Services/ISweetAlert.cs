using static VisitorManagement.Enum.SweetAlertEnum;

namespace VisitorManagement.Services
{
    public interface ISweetAlert
    {
        string AlertPopup(string title, string message, NotificationType notificationType);
        string AlertCancel(string title, string message, string buttonText, NotificationType notificationType);
        string AlertOptions(string title, string message, NotificationType notificationType);
        string AlertPopupWithImage(string title, string message, NotificationType notificationType);


    }
}