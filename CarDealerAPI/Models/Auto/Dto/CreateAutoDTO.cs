using System.ComponentModel.DataAnnotations;

namespace CarDealerAPI.Models.Auto.Dto
{
    public class CreateAutoDTO
    {
        [Required(ErrorMessage = "La marca del auto es obligatoria")]
        [StringLength(100, ErrorMessage = "La marca no puede exceder los 100 caracteres.")]
        public string Marca { get; set; } = null!;

        [Required(ErrorMessage = "El precio del auto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio del auto debe ser mayor a 0")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El estado de disponibilidad es requerido.")]
        public bool Disponible { get; set; }

        [Required(ErrorMessage = "El motor es un campo requerido.")]
        public string Motor { get; set; } = null!;

        [Required(ErrorMessage = "El año del modelo es requerido.")]
        [Range(1800, 2023, ErrorMessage = "El año del modelo debe ser menor o igual al año actual.")]
        public int Año_Modelo { get; set; }

        [Required(ErrorMessage = "Seleccione un tipo de auto")]
        public int Id_Tipo_Auto { get; set; }
    }
}
