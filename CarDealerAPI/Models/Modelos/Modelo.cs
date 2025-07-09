using CarDealerAPI.Models.Marcas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerAPI.Models.Modelos
{
    public class Modelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Modelo { get; set; }
        public string Nombre_Modelo { get; set; } = null!;
        public int Id_Marca { get; set; }
        public Marca Marca { get; set; } = null!;

    }
}
