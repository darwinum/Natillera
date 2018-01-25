using ModelosEntidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelosEntidades
{
    public interface INatillera
    {
        IEnumerable<Natillera> ObtenerTodas();
        Natillera ObtenerById(int? natilleraID);
        void Insertar(Natillera natillera);
        void Actualizar(Natillera natillera);
        void EliminarNatillera(int natilleraID);
    }
}
