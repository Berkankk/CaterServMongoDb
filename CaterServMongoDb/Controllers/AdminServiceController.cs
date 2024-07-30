using AutoMapper;
using CaterServMongoDb.Dtos.ServiceDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDb.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;
        public AdminServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _serviceService.GetAllServices();
            return View(value);
        }

        public async Task<IActionResult> DeleteService(string id)
        {
            await _serviceService.DeleteService(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceService.CreateService(createServiceDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(string id)
        {
            var value = await _serviceService.GetServiceById(id);
            var gnc = _mapper.Map<UpdateServiceDto>(value);
            return View(gnc);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceService.UpdateService(updateServiceDto);
            return RedirectToAction("Index");
        }
    }
}
