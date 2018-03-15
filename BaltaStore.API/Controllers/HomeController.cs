using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.API.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public string Get()
        {
            return "Olá Mundo";
        }
    }
}