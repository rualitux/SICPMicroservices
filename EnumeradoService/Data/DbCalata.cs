using EnumeradoService.Models;

namespace EnumeradoService.Data
{
    public static class DbCalata
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Enumerados.Any())
            {
                Console.WriteLine("Seedeando data... checa el API sobrino");
                context.Enumerados.AddRange(
                        new Enumerado() { Valor = "Animal", Descripcion = "Animales" },
                        new Enumerado() { Valor = "Perro", Descripcion = "Animal Canino" },
                        new Enumerado() { Valor = "Oficina", Descripcion = "Artículos de oficina" },
                        new Enumerado() { Valor = "Alta", Descripcion = "Procedimiento de Alta de bienes patrimoniales" }

                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ya hay datos");
            }

        }
    }
}
