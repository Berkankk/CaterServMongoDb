﻿using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.UILayout
{
    public class _UILayoutModalComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
