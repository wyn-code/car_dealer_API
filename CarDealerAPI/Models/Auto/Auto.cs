using Car_DealerShip_Proyect.Models.Tipo_Auto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_DealerShip_Proyect.Models.Auto
{
    public class Auto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Autos { get; set; }
        public string Marca { get; set; }
        public bool Usado { get; set; }
        public bool EsCeroKM {get; set;}
        public bool Disponible { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Motor { get; set; }
        public int Año_Modelo { get; set; }
        public string Id_Local { get; set; }

        [ForeignKey("Id_Tipo_Auto")]
        public List<TipoDeAuto> Tipo_Autos { get; set; }
        public int Id_Tipo_Auto { get; set; }  
        
        public DateTime fecha_creacion {  get; set; }

    }
}
