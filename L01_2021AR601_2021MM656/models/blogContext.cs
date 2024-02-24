using L01_2021AR601_2021MM656.Controllers;
using Microsoft.EntityFrameworkCore;

namespace L01_2021AR601_2021MM656.models
{
    public class blogContext:DbContext
    {
        public blogContext(DbContextOptions<blogContext> options) : base(options)
        {

        }

        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<calificaciones> calificaciones { get; set; }
        public DbSet<comentarios> comentarios { get; set; }
    }
}
