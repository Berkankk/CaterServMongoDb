using AutoMapper;
using CaterServMongoDb.Dtos.CheffDtos;
using CaterServMongoDb.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CaterServMongoDb.Controllers
{
    public class AdminCheffController : Controller
    {
        private readonly ICheffService _cheffService;
        private readonly IMapper _mapper;
        public AdminCheffController(ICheffService cheffService, IMapper mapper)
        {
            _cheffService = cheffService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _cheffService.GetAllCheffs();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCheff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCheff(CreateCheffDto createCheffDto)
        {
            await _cheffService.CreateCheff(createCheffDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCheff(string id)
        {
            var value = await _cheffService.GetCheffById(id);
            var maping = _mapper.Map<UpdateCheffDto>(value);
            return View(maping);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCheff(UpdateCheffDto updateCheffDto)
        {
            await _cheffService.UpdateCheff(updateCheffDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCheff(string id)
        {
            await _cheffService.DeleteCheff(id);
            return RedirectToAction("Index");
        }
    }
}
