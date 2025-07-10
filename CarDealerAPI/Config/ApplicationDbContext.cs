using CarDealerAPI.Models.Auto;
using CarDealerAPI.Models.Estado;
using CarDealerAPI.Models.Marcas;
using CarDealerAPI.Models.Modelos;
using CarDealerAPI.Models.Tipo_Auto;
using CarDealerAPI.Models.Provincia;
using Microsoft.EntityFrameworkCore;
using System;
using CarDealerAPI.Models.Es0Km;

namespace CarDealerAPI.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Auto> Autos { get; set; } = null!;
        public DbSet<Estado> Estados { get; set; } = null!;
        public DbSet<TipoDeAuto> TiposDeAuto { get; set; } = null!;
        public DbSet<Marca> Marcas { get; set; } = null!;
        public DbSet<Modelo> Modelos { get; set; } = null!;
        public DbSet<Condicion> Condicion { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDeAuto>().HasIndex(a => a.tipo_autos).IsUnique();

            modelBuilder.Entity<Marca>().HasData(
                new Marca { Id_Marca = 1, Nombre_Marca = "Toyota" }
            );

            modelBuilder.Entity<Modelo>()
                .HasOne(m => m.Marca)
                .WithMany(ma => ma.Modelos)
                .HasForeignKey(m => m.Id_Marca);

            modelBuilder.Entity<Modelo>().HasData(
                new Modelo { Id_Modelo = 1, Nombre_Modelo = "Corolla", Id_Marca = 1 }
            );

            modelBuilder.Entity<TipoDeAuto>().HasData(
                new TipoDeAuto { Id_Tipo_Auto = 1, tipo_autos = "Sedan" },
                new TipoDeAuto { Id_Tipo_Auto = 2, tipo_autos = "SUV" },
                new TipoDeAuto { Id_Tipo_Auto = 3, tipo_autos = "Pickup" },
                new TipoDeAuto { Id_Tipo_Auto = 4, tipo_autos = "Coupé" },
                new TipoDeAuto { Id_Tipo_Auto = 5, tipo_autos = "Hatchback" },
                new TipoDeAuto { Id_Tipo_Auto = 6, tipo_autos = "Convertible" }
            );

            modelBuilder.Entity<Estado>().HasData(
                new Estado { Id = 1, Nombre = "Disponible" },
                new Estado { Id = 2, Nombre = "Vendido" }
            );

            modelBuilder.Entity<Condicion>().HasData(

                new Condicion { Id_condicion = 1, condicionName= "0KM" },
                new Condicion { Id_condicion = 2, condicionName = "Usado" }

            );

            modelBuilder.Entity<Auto>().Property(a => a.fecha_creacion).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Auto>().HasData(
                new Auto
                {
                    Id_Autos = 1,
                    Marca = "Toyota",
                    Id_condicion = 1,
                    Disponible = true,
                    Precio = 35000.00,
                    Descripcion = "Toyota Corolla usado, excelente estado, único dueño.",
                    Motor = "1.8L 4 cilindros",
                    Año_Modelo = 2019,
                    Id_Tipo_Auto = 1,
                    EstadoId = 1,
                    Id_Modelo = 1,
                    fecha_creacion = new DateTime(2023, 1, 1)
                }
            );
        }

    }
}
