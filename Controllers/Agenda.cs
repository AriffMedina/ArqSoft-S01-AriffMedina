using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    public class Agenda : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
