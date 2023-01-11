using InventarioService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Enumerado> Enumerados { get; set; }
        public DbSet<BienPatrimonial> BienesPatrimoniales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Enumerado>()
                .HasMany(p => p.BienesPatrimoniales)
                .WithOne(p => p.Enumerado!)
                .HasForeignKey(p => p.EnumeradoId);
            modelBuilder
                .Entity<BienPatrimonial>()
                .HasOne(p => p.Enumerado)
                .WithMany(p => p.BienesPatrimoniales)
                .HasForeignKey(p => p.EnumeradoId);
        }
    }
}
