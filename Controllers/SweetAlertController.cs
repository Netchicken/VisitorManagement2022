using Microsoft.AspNetCore.Mvc;

using static VisitorManagement.Enum.SweetAlertEnum;

namespace VisitorManagement.Controllers
{
    public class SweetAlertController : SweetAlertBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            Alert("This is a success message", NotificationType.success);

            Alert("This is NOT a success message", NotificationType.error);
            return View();
        }
    }
}
