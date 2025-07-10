using CarDealerAPI.Models.Tipo_Auto.Dto;

namespace CarDealerAPI.Models.Auto.Dto
{
    public class AllAutoDTO
    {
        public int Id_Autos { get; set; }
        public string Marca { get; set; } = null!;
        public string Condicion { get; set; }
        public bool Disponible { get; set; }
        public double Precio { get; set; }
        public string? Descripcion { get; set; } 
        public string Motor { get; set; } = null!;
        public int Año_Modelo { get; set; }
        public string Tipo_Auto { get; set; } = null!;

    }
}
