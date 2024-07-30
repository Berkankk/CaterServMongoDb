using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Admin
{
    public class _AdminFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
