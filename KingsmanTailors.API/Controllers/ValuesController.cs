using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingsmanTailors.API.Data;
using KingsmanTailors.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KingsmanTailors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            // throw new Exception("Test exception!!!");
            // get the data from the database
            var models = await _context.Values.ToListAsync();
            return Ok(models);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var model = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _context.Values.Add(new Value { Name = value });
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
