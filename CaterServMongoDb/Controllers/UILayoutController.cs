using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
