using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsNG.Data;
using PartsNG.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackages([FromQuery]PartType[] types)
        {
            if(types.Count() == 0)
                return await _context.Packages
                    .OrderByDescending(p => p.Name).ToListAsync();
            else
            {
                return await _context.Packages
                    .Where(p => types.Contains(p.PartType))
                    .OrderByDescending(p => p.Name).ToListAsync();
            }
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
            var Package = await _context.Packages.FindAsync(id);

            if (Package == null)
            {
                return NotFound();
            }

            return Package;
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, Package Package)
        {
            if (id != Package.Id)
            {
                return BadRequest();
            }

            _context.Entry(Package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Packages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package Package)
        {
            _context.Packages.Add(Package);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = Package.Id }, Package);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Package>> DeletePackage(int id)
        {
            var Package = await _context.Packages.FindAsync(id);
            if (Package == null)
            {
                return NotFound();
            }

            _context.Packages.Remove(Package);
            await _context.SaveChangesAsync();

            return Package;
        }

        private bool PackageExists(int id)
        {
            return _context.Packages.Any(e => e.Id == id);
        }
    }
}
