namespace FinanceManagementMvcUi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;

    public class AdminController : Controller
    {
        private readonly AdminService _adminService;

        public AdminController()
        {
            _adminService = new AdminService();
        }

        // GET: Admin
        public ActionResult Index()
        {
            var adminViewModel = _adminService.GetAdminViewModel();
            return View(adminViewModel);
        }        
    }
}