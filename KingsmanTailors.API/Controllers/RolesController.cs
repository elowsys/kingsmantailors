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
    public class RolesController : ControllerBase
    {
        private readonly IRepository<Role> _repo;
        private readonly IMapper _mapper;
        public RolesController(IRepository<Role> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var data = await _repo.GetAll();
            var result = _mapper.Map<List<RoleForListDto>>(data);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(string id)
        {
            var data = await _repo.Find(x => x.RoleId == id);
            var result = _mapper.Map<RoleForDetailedDto>(data);
            return Ok(result);
        }
    }
}
