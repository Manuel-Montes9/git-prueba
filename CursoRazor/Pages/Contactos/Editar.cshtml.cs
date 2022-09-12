using CursoRazor.Datos;
using CursoRazor.Modelos.ViewModels;
using CursoRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CursoRazor.Pages.Contactos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
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
            if (ModelState.IsValid)
            {
                var ContactoDesdeDb = await _context.Contactos.FindAsync(ContactoVM.Contactos.Id);
                ContactoDesdeDb.Nombre = ContactoVM.Contactos.Nombre;
                ContactoDesdeDb.Email = ContactoVM.Contactos.Email;
                ContactoDesdeDb.Telefono = ContactoVM.Contactos.Telefono;
                ContactoDesdeDb.CategoriaId = ContactoVM.Contactos.CategoriaId;
                ContactoDesdeDb.FechaCreacion = ContactoVM.Contactos.FechaCreacion;

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
