using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace p.Models
{
    public class ProyContext : IdentityDbContext
    {
        public DbSet<Cliente> Cliente {get;set;}

        public ProyContext(DbContextOptions<ProyContext> options) : base(options){ }

    }
}