using CarDealerAPI.Models.Tipo_Auto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerAPI.Models.Auto
{
    public class Auto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Autos { get; set; }
        public string Marca { get; set; } = null!;
        public bool Usado { get; set; }
        public bool EsCeroKM {get; set;}
        public bool Disponible { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Motor { get; set; } = null!;
        public int Año_Modelo { get; set; }
        public string Id_Local { get; set; } = null!;

        [ForeignKey("Id_Tipo_Auto")]
        public required List<TipoDeAuto> Tipo_Autos { get; set; } 
        public int Id_Tipo_Auto { get; set; }  
        
        public DateTime fecha_creacion {  get; set; }

    }
}
