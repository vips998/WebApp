using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApp.Models;
using WebApp.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebApp.Controllers
{
    [Route("api/services")]
    [EnableCors]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly FitnesContext _context;
        public ServiceController(FitnesContext context)
        {
            _context = context;
        }

        // GET:
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetService()
        {
            return await _context.Service.Include(p => p.Record).Include(g => g.Coach).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetBlog(int id)
        {
            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return service;
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> PostBlog(ServiceDTO service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Service g = new Service
            {
                CoachID = service.CoachID,
                Name = service.Name,
                Price = service.Price,
                Description = service.Description,
                Coach = _context.Coach.Find(service.CoachID)
            };

            _context.Service.Add(g);
            _context.SaveChanges();
            return CreatedAtAction("GetService", new { id = g.ID }, g);

           /* _context.Service.Add(new Service { CoachID = service.CoachID, Name = service.Name, Price = service.Price, Description = service.Description });
            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetUser", new { id = user.ID }, user);
            return CreatedAtAction("services", new { id = service.ID }, service);*/
        }

        // PUT: 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, ServiceDTO service)
        {
            if (id != service.ID)
            {
                return BadRequest();
            }
            _context.Entry(service).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
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
        private bool BlogExists(int id)
        {
            return _context.Service.Any(e => e.ID == id);
        }


        // DELETE:
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var user = await _context.Service.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Service.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
