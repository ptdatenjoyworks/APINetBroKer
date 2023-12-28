using Microsoft.AspNetCore.Mvc;

namespace NetBrokerOpenIddict.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
