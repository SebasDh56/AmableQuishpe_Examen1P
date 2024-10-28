using System.ComponentModel.DataAnnotations;

namespace AmableQuishpe_Examen1P.Models
{
    public class AQAuto
    {

        [Key]
        public int AQAutoID { get; set; }

        [Required]
        [StringLength(50)]
        public string? AQMarca { get; set; }
        
        public int AQAnio { get; set; }

        public string? AQCombustible { get; set; }

        public bool AQUsado { get; set; }

        [Range(0.01, 9999)]
        public decimal AQPrecio { get; set; }

        [EmailAddress]
        public string? AqEmaildistribuidor { get; set; }

        public DateTime AQFechaIngreso { get; set; }

    }
}
