using CursoRazor.Datos;
using CursoRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CursoRazor.Pages.Contactos
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetalleModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contacto Contacto { get; set; }

        public async void OnGet(int id)
        {
            Contacto = await _context.Contactos
                .Where(c => c.Id == id)
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync();
        }
    }
}
