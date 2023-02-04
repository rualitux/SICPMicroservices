

using Microsoft.EntityFrameworkCore;
using MovimientoService.Models;

namespace MovimientoService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }
        public DbSet<Movimiento>Movimientos { get; set; }   
    }
}
