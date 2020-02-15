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
    public class PackagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageViewModel>>> GetPackages([FromQuery]PartType[] types)
        {
            ICollection<Package> packages;
            if (types.Count() == 0)
                packages = await _context.Packages
                    .OrderByDescending(p => p.Name).ToListAsync();
            else
            {
                packages = await _context.Packages
                    .Where(p => types.Contains(p.PartType))
                    .OrderByDescending(p => p.Name).ToListAsync();
            }

            return packages.Select(p => p.ToViewModel()).ToArray();
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageViewModel>> GetPackage(int id)
        {
            var package = await _context.Packages.FindAsync(id);

            if (package == null)
                return NotFound();

            return package.ToViewModel();
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, PackageViewModel package)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

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
        public async Task<ActionResult<Package>> PostPackage(PackageViewModel packageViewModel)
        {
            var package = await _context.Packages.FindAsync(packageViewModel.Id);
            package = (package ?? new Package()).AssignToModel(packageViewModel);
            if (package.Id == 0)
                _context.Packages.Add(package);
            else
                _context.Packages.Update(package);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePackage(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool PackageExists(int id)
        {
            return _context.Packages.Any(e => e.Id == id);
        }
    }
}
