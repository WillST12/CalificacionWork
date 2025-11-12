using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.API.Models
{
    public class ProfesorMateria
    {
        [Key]
        public int IdProfesorMateria { get; set; }

        [Required]
        [ForeignKey("Profesor")]
        public int IdProfesor { get; set; }

        [Required]
        [ForeignKey("Materia")]
        public int IdMateria { get; set; }

       
        public Profesor Profesor { get; set; }
        public Materia Materia { get; set; }
    }
}
