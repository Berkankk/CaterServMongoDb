using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.UILayout
{
    public class _UILayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
