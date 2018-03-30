using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}