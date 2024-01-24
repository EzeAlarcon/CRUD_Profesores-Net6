using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crud_Profesores.Models
{
    public class Profesores
    {
        // Identificador único del profesor
        public int Id { get; set; }

        // Nombre del profesor
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximum of {1} characters.")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Name { get; set; } = null!;

        // Materia del profesor
        [DataType(DataType.MultilineText)]
        [Display(Name = "Subject")]
        [MaxLength(500, ErrorMessage = "The field {0} must have a maximum of {1} characters.")]
        public string Subject { get; set; } = null!;

        // Grado (cambio de nombre para representar el grado)
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public decimal Grade { get; set; }
    }
}

