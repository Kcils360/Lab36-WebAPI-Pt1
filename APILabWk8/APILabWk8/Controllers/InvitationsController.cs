using APILabWk8.Data;
using APILabWk8.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabWk8.Controllers
{
    [Route("api/[controller]")]   //+++++++++++++++++++++++++++++++++Route Token attribute routing
    public class InvitationsController : ControllerBase
    {
        private readonly InviteDbContext _context;

        public InvitationsController(InviteDbContext Context)
        {
            _context = Context;
        }
        //get
        [HttpGet]
        public IEnumerable<GuestInvites> GetAll()
        {
            return _context.GuestInvites.ToList();
        }

        //get
        [HttpGet("{id:int}", Name = "GetInvite")]  //id constraints
        public IActionResult Get(int id)           //model binding
        {
            var result = _context.GuestInvites.FirstOrDefault(i => i.ID == id);  //the linq querry
            return Ok(result);
        }

        //post
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody] GuestInvites guestInvite)
        {
            if (guestInvite == null)
            {
                return BadRequest();
            }
            await _context.GuestInvites.AddAsync(guestInvite);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetInvite", new { id = guestInvite.ID }, guestInvite);
        }
    }
}
