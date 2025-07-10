using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerAPI.Models.Es0Km
{
    public class Condicion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_condicion { get; set; }
        
        public string condicionName {  get; set; }
    }
}
