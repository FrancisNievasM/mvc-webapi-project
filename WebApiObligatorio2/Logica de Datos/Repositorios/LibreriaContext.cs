using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;


namespace LogicaDatos.Repositorios {

    public class LibreriaContext : DbContext {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Parametros> Parametros { get; set; }


        public LibreriaContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //ACÁ ES DONDE AGREGARÍAMOS NUESTRO CÓDIGO FLUENT API 

            //COSAS COMO ESTA LAS PODEMOS HACER CON DATA ANNOTATIONS
            //modelBuilder.Entity<Autor>().ToTable("Authors");

            //COSAS COMO ESTA, SOLAMENTE CON FLUENT API
            modelBuilder.Entity<Usuario>().OwnsOne(au => au.Nombre);
            modelBuilder.Entity<Usuario>().OwnsOne(au => au.Apellido);
            modelBuilder.Entity<Usuario>().OwnsOne(au => au.Mail);
            modelBuilder.Entity<Usuario>().OwnsOne(au => au.Tipo);
            modelBuilder.Entity<Movimiento>().OwnsOne(au => au.Mail);

            }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);

            //AHORA LO CONFIGURAMOS A NIVEL DE PROGRAM
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLOCALDB; Initial Catalog=LibreriaN3G_2024; Integrated Security=SSPI;");
        }
}
}

