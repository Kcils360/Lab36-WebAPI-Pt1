using APILabWk8.Data;
using APILabWk8.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabWk8.Controllers
{
    [Route("api/invitations")]   //+++++++++++++++++++++++++++++++++attribute routing
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
        [HttpGet("{id}", Name = "GetInvite")]  //id constraints
        public IActionResult Get(int id)
        {
            var result = _context.GuestInvites.FirstOrDefault(i => i.ID == id);
            return Ok(result);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post([FromBody] GuestInvites guestInvite)
        {
            if (guestInvite == null)
            {
                return BadRequest();
            }
            _context.GuestInvites.Add(guestInvite);
            _context.SaveChanges();
            return CreatedAtRoute("GetInvite", new { id = guestInvite.ID }, guestInvite);
        }
    }
}
