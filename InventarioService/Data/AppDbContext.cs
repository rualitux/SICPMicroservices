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
        public DbSet<Procedimiento> Procedimientos { get; set; }

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
            modelBuilder
                .Entity<BienPatrimonial>()
                .HasOne(p => p.Procedimiento)
                .WithMany()
                .HasForeignKey(p => p.ProcedimientoId);
            //Procedimiento

            modelBuilder.Entity<Procedimiento>()
                .HasOne(r => r.ProcedimientoTipo)
                .WithMany()
                .HasForeignKey(r => r.ProcedimientoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<Procedimiento>()
               .HasOne(r => r.CausalAlta)
               .WithMany()
               .HasForeignKey(r => r.CausalAltaId)
               .OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<Procedimiento>()
              .HasOne(r => r.CausalBaja)
              .WithMany()
              .HasForeignKey(r => r.CausalBajaId)
              .OnDelete(DeleteBehavior.Restrict);






        }
    }
}
