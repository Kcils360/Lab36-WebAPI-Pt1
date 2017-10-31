using APILabWk8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabWk8.Data
{
    public class InviteDbContext : DbContext
    {
        public InviteDbContext(DbContextOptions<InviteDbContext> options) : base(options)
        {

        }
        public DbSet<GuestInvites> GuestInvites { get; set; }
    }
}
