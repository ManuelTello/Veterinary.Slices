using Microsoft.AspNetCore.Mvc;

namespace Veterinary.Slices.Application.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

