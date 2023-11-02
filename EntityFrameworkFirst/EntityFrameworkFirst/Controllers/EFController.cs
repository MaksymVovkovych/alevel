using EntityFrameworkFirst.Context;
using EntityFrameworkFirst.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFController : ControllerBase
    {
        private readonly EFContext _context;

        public EFController(EFContext eFContext)
        {
            _context = eFContext;
        }

        [HttpGet]

        public async Task<ActionResult> TestConnection()
        {

            if (_context.Database.CanConnect())
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("get-users")]

        public async Task<ActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }
    }
}
