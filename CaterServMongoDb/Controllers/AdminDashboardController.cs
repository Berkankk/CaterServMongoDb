using AutoMapper;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IMapper _mapper;
        public AdminDashboardController(IDashboardService dashboardService, IMapper mapper)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
