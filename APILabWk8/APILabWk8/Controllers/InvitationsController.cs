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
        public IEnumerable<GuestInvites> GetAll() //This entrire line is a method signature, that's why it can have the same name as 29
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

            await _context.GuestInvites.AddAsync(guestInvite);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetInvite", new { id = guestInvite.ID }, guestInvite);
        }

        //put
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] GuestInvites guestInvites)
        {
            if(!ModelState.IsValid)
            {
                return (BadRequest(ModelState));
            }
            var check = _context.GuestInvites.FirstOrDefault(c => c.ID == id);
            if (check != null)
            {
                check.Name = guestInvites.Name;
                check.Confirmed = guestInvites.Confirmed;
                _context.Update(check);

                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        //delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.GuestInvites.FirstOrDefault(d => d.ID == id);
            if(result != null)
            {
                _context.GuestInvites.Remove(result);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
