using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Controllers
{
    public class SpecializationsController : Controller
    {
        private readonly IEntityService<Specialization> _specializationService;
        private readonly IMapper _mapper;

        public SpecializationsController(IEntityService<Specialization> specializationService, IMapper mapper)
        {
            _specializationService = specializationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            
            return View(_mapper.
                Map<IEnumerable<SpecializationViewModel>>(await _specializationService.GetAllAsync()).ToList());
        }
    }
}
