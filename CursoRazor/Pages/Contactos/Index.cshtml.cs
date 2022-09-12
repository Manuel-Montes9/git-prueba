using CursoRazor.Datos;
using CursoRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CursoRazor.Pages.Contactos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contacto> Contactos { get; set; }
        public async Task OnGet()
        {
            Contactos = await _context.Contactos.Include(c => c.Categoria).ToListAsync();
        }
    }
}
