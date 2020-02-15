using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsNG.Data;
using PartsNG.Models;
using PartsNG.Models.Extensions;
using PartsNG.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartViewModel>>> GetParts()
        {
            var parts = (await _context.Parts
                .Include(nameof(Part.PartProperties))
                .Include(nameof(Part.Package))
                .Include($"{nameof(Part.PartProperties)}.{nameof(PartProperty.Property)}")
                .ToListAsync()).Select(p => p.ToViewModel()).ToArray();
            return parts;
        }

        // GET: api/Parts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartViewModel>> GetPart(int id)
        {
            var part = await _context.Parts
                .Include(nameof(Part.PartProperties))
                .Include(nameof(Part.Package))
                .Include($"{nameof(Part.PartProperties)}.{nameof(PartProperty.Property)}")
                .FirstAsync(p => p.Id == id);

            if (part == null)
            {
                return NotFound();
            }

            return part.ToViewModel();
        }

        // PUT: api/Parts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPart(int id, PartViewModel partViewModel)
        {
            var part = await _context.Parts.FindAsync(partViewModel.Id);
            part.AssignToModel(partViewModel);
            var partProperties = partViewModel.PartProperties?.Select(p => new PartProperty().AssignToModel(p)).ToList();
            foreach (var partProperty in partProperties)
            {
                partProperty.PartId = part.Id;
            }
            _context.Parts.Update(part);
            _context.PartProperties.RemoveRange(
                _context.PartProperties.Where(pp => pp.PartId == part.Id)
                );
            await _context.AddRangeAsync(partProperties);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Parts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PartViewModel>> PostPart(PartViewModel partViewModel)
        {
            var part = new Part().AssignToModel(partViewModel);
            var partProperties = partViewModel.PartProperties?.Select(p => new PartProperty().AssignToModel(p)).ToList();
            
            await _context.Parts.AddAsync(part);
            await _context.SaveChangesAsync();

            foreach (var partProperty in partProperties)
            {
                partProperty.PartId = part.Id;
            }

            await _context.AddRangeAsync(partProperties);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPart", new { id = part.Id }, part);
        }

        // DELETE: api/Parts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePart(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part == null)
                return NotFound();

            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool PartExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }
    }
}
