using BootcampDIO_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BootcampDIO_Api.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
            
        }

        public DbSet<Contato> Contatos{ get; set;}
    }
}