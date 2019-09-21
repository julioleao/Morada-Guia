using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoradaGuia.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MoradaGuia.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _Context;
        public ValuesController(DataContext context)
        {
            _Context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _Context.Values.ToListAsync();

            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _Context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
