using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_DealerShip_Proyect.Models.Provincia
{
    public class Provincias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cod_provincia {get; set;}
        public string Nomb_provincia { get; set; } 

    }
}
