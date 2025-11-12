namespace Backend.API.Models.DTOs
{
    public class ClaseDTO
    {
       public int IdProfesorMateria { get; set; }
        public string Periodo { get; set; }

        public bool Activo { get; set; } = true;
    }
}
