using VisitorManagement.Enum;

namespace VisitorManagement.Operations
{
    public interface ISweetAlert
    {
        string Alert(string title, string message, SweetAlertEnum.NotificationType notificationType);
    }
}