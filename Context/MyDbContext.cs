using Microsoft.EntityFrameworkCore;
using Musica2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musica2.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Con esto estamos utilizando ApiFluent y le estamos diciendo que la entidad
            //Estudiante curso va a tener una clave primaria compuesta por CursoId y
            //EstudianteId
            modelBuilder.Entity<CancionesUsuarios>()
           .HasKey(x => new { x.UsuariosId, x.CancionesId });
        }

        public DbSet<Artistas> Artistas { get; set; }
        public DbSet<Canciones> Canciones { get; set; }
        public DbSet<DatosBancarios> DatosBancarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<CancionesUsuarios> CancionesUsuarios { get; set; }


    }
}

