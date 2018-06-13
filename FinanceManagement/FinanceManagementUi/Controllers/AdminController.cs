namespace FinanceManagementUi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: /<controller>/
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
