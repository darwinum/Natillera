using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelosEntidades;
using nati = ModelosEntidades.Models;

namespace pryNatillera.Pages.Natillera
{
    public class EditModel : PageModel
    {
        private readonly INatillera _ina;

        public EditModel(INatillera ina)
        {
            _ina = ina;
        }

        [BindProperty]
        public nati.Natillera Natillera { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Natillera = _ina.ObtenerById(id);

            if (Natillera == null)
            {
                return NotFound();
            }
            return Page();
        }

        public  IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _ina.Actualizar(Natillera);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!_context.Movie.Any(e => e.ID == Movie.ID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return RedirectToPage("Index");
        }

    }
}