using Microsoft.AspNetCore.Mvc;
using PartsNG.Data;
using PartsNG.Models;
using PartsNG.Models.Extensions;
using PartsNG.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PartsNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyViewModel>> GetProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return property.ToViewModel();
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(PropertyViewModel propertyViewModel)
        {
            var property = await _context.Properties.FindAsync(propertyViewModel.Id);
            property = property.AssignToModel(propertyViewModel);

            _context.Properties.Update(property);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Properties
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PropertyViewModel>> PostProperty(PropertyViewModel propertyViewModel)
        {
            if (propertyViewModel.Name == "" && propertyViewModel.Name.Length < 3)
                return BadRequest();

            var count = await _context.Properties.CountAsync(p => p.Name == propertyViewModel.Name);
            if (count > 0)
                return BadRequest();

            var property = new Property().AssignToModel(propertyViewModel);
            _context.Properties.Add(property);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new { id = property.Id }, property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Property>> DeleteProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
