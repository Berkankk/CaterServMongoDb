using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Admin
{
    public class _AdminSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
