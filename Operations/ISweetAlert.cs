using VisitorManagement.Enum;

using static VisitorManagement.Enum.SweetAlertEnum;

namespace VisitorManagement.Operations
{
    public interface ISweetAlert
    {
        string AlertPopup(string title, string message, SweetAlertEnum.NotificationType notificationType);
        string AlertCancel(string title, string message, string buttonText, NotificationType notificationType);
        string AlertOptions(string title, string message, string buttonText1, string buttonText2, NotificationType notificationType);
        string AlertPopupWithImage(string title, string message, SweetAlertEnum.NotificationType notificationType);
    }
}