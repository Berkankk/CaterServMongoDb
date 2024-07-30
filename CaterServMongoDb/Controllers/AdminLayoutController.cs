using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
