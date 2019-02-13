using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KingsmanTailors.API.Dtos;
using KingsmanTailors.API.Interfaces;
using KingsmanTailors.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingsmanTailors.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FittingsController : ControllerBase
    {

        private readonly IRepository<OccasionFit> _repo;
        private readonly IMapper _mapper;

        public FittingsController(IRepository<OccasionFit> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repo.GetAll();
            var result = _mapper.Map<List<FitForListDto>>(data);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //var data = await _repo.Get(id);
            //var result = _mapper.Map<FitForDetailedDto>(data);
            //var data = await _repo.Find(x => x.FitId == id);
            var result = await _repo.Get(id);
            return Ok(result);
        }
    }
}
