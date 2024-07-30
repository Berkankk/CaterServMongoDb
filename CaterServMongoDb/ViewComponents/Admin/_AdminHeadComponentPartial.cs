using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Admin
{
    public class _AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
