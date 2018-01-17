using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDato.Models
{
    public class Socio
    {
   
        public int SocioId { get; set; }

        /// <summary>
        /// se selecciona la natillera para cargar los socios que pertenecen a la misma.
        /// </summary>
        //public virtual Natillera Natillera { get; set; }

        /// <summary>
        /// relacion de uno a uno con la tabla tipo documento.
        /// un socio pude tener algun tipo de documento.
        /// </summary>
        //public virtual TiposDocumento TiposDocumento { get; set; }

        [StringLength(20)]
        public string NumeroDocumento { get; set; }

        [StringLength(200)]
        public string Nombres { get; set; }
        [StringLength(250)]
        public string Apellidos { get; set; }
        [StringLength(20)]
        public string Telefono { get; set; }
        [StringLength(20)]
        public string Celular { get; set; }
        [StringLength(250)]
        public string Direccion { get; set; }
        [StringLength(150)]
        public string CorreoElectronico { get; set; }

        //propiedades que se utilizan para las relaciones
        /*Relacion uno a uno con el tipo de documento*/
        public virtual TiposDocumento TiposDocumento { get; set; }

        //relacion un socio puede pertenecer a diferentes natilleras
        public ICollection<NatilleraSocio> NatilleraSocio { get; set; }

        

    }
}
