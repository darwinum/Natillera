using LibraryDato.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDato
{
    public interface INatillera
    {
        IEnumerable<Natillera> ObtenerTodas();
        Natillera ObtenerById(int natilleraID);
        void Insertar(Natillera natillera);
        void Actualizar(Natillera natillera);
    }
}
