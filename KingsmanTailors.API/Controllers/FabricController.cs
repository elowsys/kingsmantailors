using System.Collections.Generic;
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
    public class FabricController : ControllerBase
    {
        private readonly IRepository<Fabric> _repo;
        private readonly IMapper _mapper;

        public FabricController(IRepository<Fabric> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFabrics()
        {
            var data = await _repo.GetAll();
            var result = _mapper.Map<List<FabricForListDto>>(data);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFabric(object id)
        {
            var data = await _repo.Get(id);
            var result = _mapper.Map<FabricForDetailedDto>(data);
            return Ok(result);
        }
    }
}
