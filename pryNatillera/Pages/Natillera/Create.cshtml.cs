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
    public class CreateModel : PageModel
    {
        private readonly INatillera _ina;

        public CreateModel(INatillera ina)
        {
            _ina = ina;
        }

        public void OnGet()
        {

        }

        [TempData]
        public string Message { get; set; }

        

        [BindProperty]
        public nati.Natillera Natillera { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _ina.Insertar(Natillera);            
            Message = $"Customer {Natillera.DescripcionNatillera} added";
            return RedirectToPage("/Natillera/Index");
        }
    }
}