using System.ComponentModel.DataAnnotations;

namespace CursoRazor.Modelos
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Es obligatorio el nombre de categoria")]
        [StringLength(15, ErrorMessage = "{0} el nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio el nombre de categoria")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio el nombre de categoria")]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Creacion")]
        public DateTime? FechaCreacion { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
