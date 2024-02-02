using Microsoft.EntityFrameworkCore;
using Musica2.Context;
using Musica2.Models;

namespace PruebaASP.Context
{
    public static class DbInitializer
    {

        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated(); //este método nos crea automáticamente
                                              //la BD sin migraciones, pero éstas son preferibles por si
                                              //nuestro modelo
                                              //se va modificando
                                              // Comprueba si hay algún hospital
            if (context.Artistas.Any())
            {
                return; // BD ya ha sido inicializada
            }
            //Añado hospitales
            var artistas = new Artistas[]
            {
                new Artistas { },
                new Artistas { },

            };
            context.Artistas.AddRange(artistas);
            context.SaveChanges();

            var canciones = new Canciones[]
           {
                new Canciones {  },
                new Canciones {  },
                new Canciones {},
                new Canciones {},
                new Canciones {},
                new Canciones {},

           };
           context.Canciones.AddRange(canciones);
            context.SaveChanges();

        }


    }
}
