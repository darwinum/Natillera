using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryDato;
using Microsoft.AspNetCore.Mvc;
using ModelosEntidades;

namespace pryNatillera.Controllers
{
    public class NatilleraController : Controller
    {
        private INatillera _natilla;

        public NatilleraController(INatillera natilla)
        {
            _natilla = natilla;
        }



        public IActionResult Index()
        {
            var lisNatilla = _natilla.ObtenerTodas();
            return View(lisNatilla);
        }
    }
}