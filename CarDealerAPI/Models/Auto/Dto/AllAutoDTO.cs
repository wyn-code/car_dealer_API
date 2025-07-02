namespace Car_DealerShip_Proyect.Models.Auto.Dto
{
    public class AllAutoDTO
    {
        public int Id_Autos { get; set; }
        public string Marca { get; set; } = null!;
        public bool Usado { get; set; }
        public bool EsCeroKM { get; set; }
        public bool Disponible { get; set; }
        public double Precio { get; set; }
        public string? Descripcion { get; set; } 
        public string Motor { get; set; } = null!;
        public int Año_Modelo { get; set; }
        public string Id_Local { get; set; } = null!;
        public Tipo_Auto.TipoDeAuto Tipo_Auto { get; set; } = null!;

    }
}
