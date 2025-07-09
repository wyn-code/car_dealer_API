using CarDealerAPI.Models.Modelos;
using CarDealerAPI.Models.Tipo_Auto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerAPI.Models.Marcas
{
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Marca { get; set; }
        public string Nombre_Marca { get; set; } = null!;
        public ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}
