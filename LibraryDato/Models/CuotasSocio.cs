using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDato.Models
{
    /// <summary>
    /// entidad que almacena el valor de la cuota que el socio se compromete a dar por ser parte de la natillera.
    /// </summary>
    public class CuotasSocio
    {

        [Key]
        public int CuotasSocioId { get; set; }

       

        /// <summary>
        /// relacion de muchos a uno con la tabla socios.
        /// solo se deben cargar los socios que hacen parte de la natillera.
        /// </summary>
        public virtual Socio Socio { get; set; }

        /// <summary>
        /// fecha a la cual pertenece el pago de la cuota.
        /// </summary>
        public DateTime FechaPagoCuota { get; set; }

        /// <summary>
        /// valor por defecto que se debe pagar segun lo parametrizado para la natillera
        /// </summary>
        public Decimal ValorCuota { get; set; }

        /// <summary>
        /// valor que se calcula segun las politicas de la natillera
        /// </summary>
        public Decimal ValorMulta { get; set; }

        /// <summary>
        /// valor total despues de sumar el valor de la cuota y valor de la multa.
        /// </summary>
        public Decimal ValorTotalCuota { get; set; }

        /// <summary>
        /// fecha de creacion del registro, se diligencia con la informacion del sistema.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        //RELACIONES
        /// <summary>
        /// se selecciona la natillera para cargar los socios que pertenecen a la misma.
        /// </summary>
        public virtual Natillera Natillera { get; set; }
    }
}
