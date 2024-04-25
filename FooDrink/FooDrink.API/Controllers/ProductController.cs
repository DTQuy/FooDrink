using Microsoft.AspNetCore.Mvc;

namespace FooDrink.API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
