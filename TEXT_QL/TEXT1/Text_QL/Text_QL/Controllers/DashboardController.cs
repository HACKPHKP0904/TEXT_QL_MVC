using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Text_QL.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return View();
        }

        [Authorize(Roles = "NhanVien")]
        public IActionResult EmployeeDashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            if (role == "Admin")
            {
                return RedirectToAction("AdminDashboard");
            }
            else if (role == "NhanVien")
            {
                return RedirectToAction("EmployeeDashboard");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
