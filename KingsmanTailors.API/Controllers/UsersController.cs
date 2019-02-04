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
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repo;
        private readonly IMapper _mapper;
        public UsersController(IRepository<User> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.Get(id);
            var result = _mapper.Map<UserForDetailedDto>(user);
            return Ok(result);
        }

        [HttpGet("uid/{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _repo.Find(x => x.UserId == userId);
            var result = _mapper.Map<UserForDetailedDto>(user);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetAll();
            var result = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(result);
        }
    }
}
