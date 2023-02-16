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
                            new BienPatrimonial() { Denominacion = "Perro", EnumeradoId= 1, Categoria = "Animales", Color ="Negro"},
                            new BienPatrimonial() { Denominacion = "Perro2", EnumeradoId = 1, Categoria = "Animales", Color = "Dorado"},
                            new BienPatrimonial() { Denominacion = "Botecito 3", EnumeradoId =2, Categoria = "Bote", Marca ="Wanxin" }                        
                                );
                    context.Enumerados.AddRange(
                            //1
                            new Enumerado() { Valor = "Animales" },
                            new Enumerado() { Valor = "Bote" },
                            //3
                            new Enumerado() { Valor = "Donacion" },
                            new Enumerado() { Valor = "Reposición" },
                            //5
                            new Enumerado() { Valor = "Central" },
                            new Enumerado() {Valor  = "GERFFS" },
                            new Enumerado() {Valor = "Activo" },
                            //8
                            new Enumerado() { Valor ="A" },
                            new Enumerado() {Valor = "Bueno" },
                           //10
                            new Enumerado() { Valor = "Alta" }
                    );
                context.Procedimientos.AddRange(
                        new Procedimiento() { NombreReferencial = "Alta Animales", CausalString = "Donación", CausalId =3, ProcedimientoTipoString = "Alta", ProcedimientoTipoId =10},
                        new Procedimiento() { NombreReferencial = "Alta Navíos", CausalString = "Reposición", CausalId = 4, ProcedimientoTipoString = "Alta", ProcedimientoTipoId = 10 }

                    );
                context.ProcedimientoBiens.AddRange(
                    new ProcedimientoBien() {BienPatrimonialId = 1, BienPatrimonialString = "Perro", ProcedimientoId = 1, ProcedimientoString = "Alta Animales" }
                    );
                context.Areas.AddRange(
                    new Area() {Nombre = "Sistemas", SedeString = "Central", SedeId = 5, DependenciaString ="GERFFS", DependenciaId = 6, EstadoAreaString = "Activo", EstadoAreaId = 7  },                   
                new Area() { Nombre = "Patrimonio", SedeString = "Central", SedeId = 5, DependenciaString = "GERFFS", DependenciaId = 6, EstadoAreaString = "Activo", EstadoAreaId = 7 }
                    );
                context.Inventarios.AddRange(
                   new Inventario()
                   {
                       Cantidad = 1,
                       BienPatrimonialString = "Perro",
                       BienPatrimonialId = 1,
                       AreaString = "Sistemas",
                       AreaId = 1,
                       AnexoTipoString = "A",
                       AnexoTipoId = 8,
                       EstadoBienString = "Activo",
                       EstadoBienId = 7,
                       EstadoCondicionString = "Bueno",
                       EstadoCondicionId = 9
                   },               
                   new Inventario()
                {
                    Cantidad = 3,
                    BienPatrimonialString = "Botecito 3",
                    BienPatrimonialId = 3,
                    AreaString = "Patrimonio",
                    AreaId = 2,
                    AnexoTipoString = "A",
                    AnexoTipoId = 8,
                    EstadoBienString = "Activo",
                    EstadoBienId = 7,
                    EstadoCondicionString = "Bueno",
                    EstadoCondicionId = 9
                }
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


