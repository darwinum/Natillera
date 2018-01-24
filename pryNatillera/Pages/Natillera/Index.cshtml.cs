using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelosEntidades;
using nati = ModelosEntidades.Models;
using LibraryServicios;
using Microsoft.EntityFrameworkCore;

namespace pryNatillera.Pages.Natillera
{
    public class IndexModel : PageModel
    {

        private readonly INatillera _ina;

        public IndexModel(INatillera ina)
        {
            _ina = ina;
        }

        [BindProperty]
        public nati.Natillera Natillera { get; set; }

        //public void OnGet()
        //{
        //    //_ina.ObtenerTodas();
        //}

        public IList<nati.Natillera> Natilleras { get; private set; }

        public IActionResult OnGet()
        {
            Natilleras = _ina.ObtenerTodas().ToList();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _ina.EliminarNatillera(id);           
            return RedirectToPage("Index");           
        }

        public IActionResult OnPostAsync()
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
                throw new Exception($"Natillera {Natillera.NatilleraId} not found!");
            }
            return RedirectToPage("/Index");
        }

    }
}