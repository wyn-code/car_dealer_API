using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarDealerAPI.Models.Tipo_Auto
{
    public class TipoDeAuto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Tipo_Auto { get; set; }
        public string tipo_autos { get; set; } = null!;

        [JsonIgnore]
        public List<Auto.Auto> autos { get; set; } = new List<Auto.Auto>();
    }
}
