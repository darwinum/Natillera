using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDato.Models
{
    public class CuotasPrestamo
    {
        [Key]
        public int CuotasPrestamoId{ get; set; }        
        

        /// <summary>
        /// la cuota a que prestamo pertenece
        /// </summary>
        public  Prestamo Prestamo { get; set; }
        

        /// <summary>
        /// valor de la cuota sin cargos
        /// </summary>
        public decimal ValorCuota { get; set; }

        /// <summary>
        /// valor que contiene solo el interes
        /// </summary>
        public decimal ValorInteres { get; set; }        

        /// <summary>
        /// fecha en la cual se debe realizar el pago
        /// </summary>
        public DateTime FechaEsperaPago { get; set; }

        /// <summary>
        /// fecha cuando se aplican los dias de gracia, limite para pagar sin mora.
        /// </summary>
        public DateTime FechaLimitePago { get; set; }


        /// <summary>
        /// dias despues que se cumple o se pasa la fecha limite de pago.
        /// </summary>
        public int DiasMora { get; set; }

        /// <summary>
        /// valor que se cobra a los dias que se demoran para el pago de las cuotas, esto despues del limite de pago.
        /// </summary>
        public decimal ValorDiasMora { get; set; }


        /// <summary>
        /// valor que contiene la suma del interes y el valor de la cuota.
        /// </summary>
        public decimal ValorNetoPagoCuota { get; set; }


    }
}
