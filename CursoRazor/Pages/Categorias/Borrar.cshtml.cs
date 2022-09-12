using CursoRazor.Datos;
using CursoRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CursoRazor.Pages.Categorias
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BorrarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async void OnGet(int id)
        {
            Categoria = await _context.Categoria.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
                var CategoriaDesdeDb = await _context.Categoria.FindAsync(Categoria.Id);
                if (CategoriaDesdeDb == null)
                {
                    return NotFound();
                }
                _context.Categoria.Remove(CategoriaDesdeDb);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
        }
    }
}
