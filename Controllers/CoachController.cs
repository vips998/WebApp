using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApp.Models;
using WebApp.DTO;
using Microsoft.AspNetCore.Cors;

namespace WebApp.Controllers
{
    [Route("api/coachs")]
    [EnableCors]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly FitnesContext _context;

        public CoachController(FitnesContext context)
        {
            _context = context;
        }

        // GET:
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoach()
        {
            return await _context.Coach.ToListAsync();
        }
    }
}
