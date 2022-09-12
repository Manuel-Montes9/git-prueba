using CursoRazor.Datos;
using CursoRazor.Modelos.ViewModels;
using CursoRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CursoRazor.Pages.Contactos
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BorrarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearContactoVM ContactoVM { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _context.Categoria.ToListAsync(),
                Contactos = await _context.Contactos.FindAsync(id)
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var ContactoDesdeDb = await _context.Contactos.FindAsync(ContactoVM.Contactos.Id);
            if (ContactoDesdeDb == null)
            {
                return NotFound();
            }
            _context.Contactos.Remove(ContactoDesdeDb);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
