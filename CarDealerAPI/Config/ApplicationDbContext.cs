using CarDealerAPI.Models.Auto;
using CarDealerAPI.Models.Tipo_Auto;
using Microsoft.EntityFrameworkCore;

namespace CarDealerAPI.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Auto> Autos { get; set; } = null!;
        public DbSet<TipoDeAuto> TiposDeAuto { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDeAuto>().HasIndex(a => a.tipo_autos).IsUnique();
            modelBuilder.Entity<TipoDeAuto>().HasData(
                new TipoDeAuto { Id_Tipo_Auto = 1, tipo_autos = "Sedan" },
                new TipoDeAuto { Id_Tipo_Auto = 2, tipo_autos = "SUV" },
                new TipoDeAuto { Id_Tipo_Auto = 3, tipo_autos = "Pickup" },
                new TipoDeAuto { Id_Tipo_Auto = 4, tipo_autos = "Coupé" },
                new TipoDeAuto { Id_Tipo_Auto = 5, tipo_autos = "Hatchback" },
                new TipoDeAuto { Id_Tipo_Auto = 6, tipo_autos = "Convertible" }
            );
        }

       //modelBuilder.Entity<Auto>().Property(a => a.FechaCreacion).HasDefaultValueSql("GETUTCDATE()");

    }
}
