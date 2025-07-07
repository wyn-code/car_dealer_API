using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerAPI.Models.Tipo_Auto
{
    public class TipoDeAuto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Tipo_Auto { get; set; }
        public string tipo_autos { get; set; } = null!;
        public List<Auto.Auto> autos { get; set; } = new List<Auto.Auto>();
    }
}
