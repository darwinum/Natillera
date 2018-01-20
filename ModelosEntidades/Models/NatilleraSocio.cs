using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelosEntidades.Models
{
    /// <summary>
    /// entidad que almacena la información relacionada de que socios pertenecen a determinada natillera
    /// </summary>
    public class NatilleraSocio
    {
        [Key]
        public int NatilleraSocioID { get; set; }

        public virtual Natillera Natillera { get; set; }

        public virtual Socio socio { get; set; }
    }
}
