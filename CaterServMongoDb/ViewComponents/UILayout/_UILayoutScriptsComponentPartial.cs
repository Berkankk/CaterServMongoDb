using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.UILayout
{
    public class _UILayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
