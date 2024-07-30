using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.ViewComponents.Default
{
    public class _DefaultTeamComponentPartial : ViewComponent
    {
        private readonly ICheffService _cheffService;

        public _DefaultTeamComponentPartial(ICheffService cheffService)
        {
            _cheffService = cheffService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _cheffService.GetAllCheffs();
            return View(value);
        }
    }
}
