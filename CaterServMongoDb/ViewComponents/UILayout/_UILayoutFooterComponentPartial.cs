using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.UILayout
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
