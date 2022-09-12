using CursoRazor.Datos;
using CursoRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;

namespace CursoRazor.Pages.Categorias
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
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
            if (ModelState.IsValid)
            {
                var CategoriaDesdeDb = await _context.Categoria.FindAsync(Categoria.Id);
                CategoriaDesdeDb.Nombre = Categoria.Nombre;
                CategoriaDesdeDb.FechaCreacion = Categoria.FechaCreacion;
                
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
