using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Admin
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
