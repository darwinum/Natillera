using System;
using System.Collections.Generic;
using LibraryDato;
using LibraryDato.Models;

namespace LibraryServicios
{
    public class NatillaServicio : INatillera
    {
        private LibraryDatoContext _context;

        public NatillaServicio( LibraryDatoContext context)
        {
            _context = context;
        }

        public void Actualizar(Natillera natillera)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Natillera natillera)
        {
            _context.Add(natillera);
            _context.SaveChanges();
        }

        public Natillera ObtenerById(int natilleraID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Natillera> ObtenerTodas()
        {
            return _context.Natilleras;
        }
    }
}
