using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.UILayout
{
    public class _UILayoutSpinnerComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
