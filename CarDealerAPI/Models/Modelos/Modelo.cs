using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarDealerAPI.Models.Modelos
{
    public class Modelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Modelo { get; set; }
        public string Nombre_Modelo { get; set; } = null!;

    }
}
