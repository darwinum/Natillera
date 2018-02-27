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
            List<TipoPagos> lTipoPago = new List<TipoPagos>()
            {
                new TipoPagos{ TipoPago=15, DescripcionPago="Quincenal" },
                 new TipoPagos{ TipoPago=30, DescripcionPago="Mensual" }
            };
        }

        [TempData]
        public string Message { get; set; }

        

        [BindProperty]
        public nati.Natillera Natillera { get; set; }

        public IActionResult OnPost()
        {
            string valor = string.Empty;
            Natillera.ValorMora =Convert.ToDecimal( Natillera.ValorMora.ToString().Replace(",","").Trim().Replace(".","").Trim());
            Natillera.ValorCuota = Convert.ToDecimal(Natillera.ValorCuota.ToString().Replace(",", "").Trim().Replace(".", "").Trim());

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _ina.Insertar(Natillera);            
            Message = $"Customer {Natillera.DescripcionNatillera} added";
            return RedirectToPage("/Natillera/Index");
        }
    }

    public class TipoPagos
    {
        public int TipoPago { get; set; }
        public string DescripcionPago { get; set; }
    }
}