using MovimientoService.Models;

namespace MovimientoService.Data
{
    public static class PrepDb
    {
        public static void Prep(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Movimientos.Any())
            {
                context.Movimientos.AddRange(
                           new Movimiento() { FechaMonvimiento = "05/05/10", TipoMoviento = "derec" },
                           new Movimiento() { JustiMovimiento ="esta no se que" }
                       );
                context.SaveChanges();
            }
        }
    }
}
