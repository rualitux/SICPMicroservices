using EnumeradoService.Models;
using Microsoft.EntityFrameworkCore;

namespace EnumeradoService.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        { 
            
        }
        public DbSet<Enumerado> Enumerados { get; set; }
        public DbSet<EnumeradoJerarquia> EnumeradoJerarquias { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            //  modelBuilder.Entity<Enumerado>()
            //    .HasOne(d => d.Padre)
            //  .WithMany(p => p.Hijo)
            //.OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Enumerado>().
                HasMany(p => p.Ancestros)
                .WithOne(d => d.Descendiente)
               .HasForeignKey(d => d.DescendienteId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Enumerado>().
                HasMany(p => p.Descendientes)
                .WithOne(d => d.Ancestro)
               .HasForeignKey(d => d.AncestroId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EnumeradoJerarquia>()
             .HasKey(p => new { p.AncestroId, p.DescendienteId });
        }
        #endregion
    }
}
