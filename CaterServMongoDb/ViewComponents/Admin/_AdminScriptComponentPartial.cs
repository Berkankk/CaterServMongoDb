using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Admin
{
    public class _AdminScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
