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
        public DbSet<Area> Areas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<ProcedimientoBien> ProcedimientoBiens { get; set; }

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
            //Procedimiento

            modelBuilder.Entity<Procedimiento>()
                .HasOne(r => r.ProcedimientoTipo)
                .WithMany()
                .HasForeignKey(r => r.ProcedimientoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<Procedimiento>()
               .HasOne(r => r.Causal)
               .WithMany()
               .HasForeignKey(r => r.CausalId)
               .OnDelete(DeleteBehavior.Restrict);                       
            //Areas
            modelBuilder.Entity<Area>()
               .HasOne(r => r.Sede)
               .WithMany()
               .HasForeignKey(r => r.SedeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Area>()
               .HasOne(r => r.Dependencia)
               .WithMany()
               .HasForeignKey(r => r.DependenciaId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Area>()
              .HasOne(r => r.EstadoArea)
              .WithMany()
              .HasForeignKey(r => r.EstadoAreaId)
              .OnDelete(DeleteBehavior.Restrict);

            //Inventario
            modelBuilder.Entity<Inventario>()
         .HasOne(r => r.AnexoTipo)
         .WithMany()
         .HasForeignKey(r => r.AnexoTipoId)
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inventario>()
               .HasOne(r => r.EstadoCondicion)
               .WithMany()
               .HasForeignKey(r => r.EstadoCondicionId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inventario>()
              .HasOne(r => r.EstadoBien)
              .WithMany()
              .HasForeignKey(r => r.EstadoBienId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
