using InventarioService.Models;

namespace InventarioService.Data
{
    public static class PrepDb
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
                if (!context.BienesPatrimoniales.Any())
                {
                    Console.WriteLine("Seedeando data... checa el API sobrino");
                    context.BienesPatrimoniales.AddRange(
                            new BienPatrimonial() { Denominacion = "Perro", Categoria = "Animales", Color ="Negro", ProcedimientoId = 1, ProcedimientoNombre ="Alta Animales" },
                            new BienPatrimonial() { Denominacion = "Perro2", Categoria = "Animales", Color = "Dorado", ProcedimientoId = 1, ProcedimientoNombre = "Alta Animales" },
                            new BienPatrimonial() { Denominacion = "Botecito 3", Categoria = "Bote", Marca ="Wanxin" }                        
                                );
                    context.Enumerados.AddRange(
                            new Enumerado() { Valor = "Animales" },
                            new Enumerado() { Valor = "Bote" },
                            new Enumerado() { Valor = "Donacion" },
                            new Enumerado() { Valor = "Reposición" }
                    );
                context.Procedimientos.AddRange(
                        new Procedimiento() { NombreReferencial = "Alta Animales", CausalAltaString = "Donación"},
                        new Procedimiento() { NombreReferencial = "Alta Navíos", CausalAltaString = "Reposición" }

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


