using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarDealerAPI.Models.Tipo_Auto;

namespace CarDealerAPI.Models.Marcas
{
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Marca { get; set; }
        public string Nombre_Marca { get; set; } = null!;

        [ForeignKey("Id_Modelo")]
        public required List<Marca> Modelos { get; set; }
    }
}
