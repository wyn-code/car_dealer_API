using System.ComponentModel.DataAnnotations;

namespace CarDealerAPI.Models.Tipo_Auto.Dto
{
    public class CreateTipoAutoDTO
    {
        [Required(ErrorMessage = "El nombre del tipo de auto es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        public string tipo_autos { get; set; } = null!;
        
    }
}
