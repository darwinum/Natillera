using System;
using System.Collections.Generic;
using LibraryDato;
using Microsoft.EntityFrameworkCore;
using ModelosEntidades;
using ModelosEntidades.Models;

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
            _context.Attach(natillera).State = EntityState.Modified;           
            _context.SaveChanges();
        }

        public void Insertar(Natillera natillera)
        {
           // _context.Attach(natillera).State = EntityState.Modified;
            _context.Add(natillera);
            _context.SaveChanges();
        }

        public Natillera ObtenerById(int? natilleraID)
        {
            return _context.Natilleras.Find(natilleraID);            
        }

        public void EliminarNatillera(int natilleraID)
        {
            Natillera natillera = ObtenerById(natilleraID);
            if (natillera != null)
            {
                _context.Natilleras.Remove(natillera);
                _context.SaveChangesAsync();
            }          
        }

        public IEnumerable<Natillera> ObtenerTodas()
        {
            return _context.Natilleras;
        }
    }
}
