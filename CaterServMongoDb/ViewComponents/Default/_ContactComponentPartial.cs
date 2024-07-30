using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Default
{
    public class _ContactComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
