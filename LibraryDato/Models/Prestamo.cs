﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDato.Models
{
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }

        /// <summary>
        /// relacion de muchos a uno con la tabla socios.
        /// un prestamo debe tener un socio que solicita el prestamo.
        /// </summary>
        public virtual Socio Socio { get; set; }

       /// <summary>
       /// fecha creacion del registro, diligenciada por el sistema.
       /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// dia en el cual se realiza la entrega de la plata.
        /// </summary>
        public DateTime FechaDesembolso { get; set; }

        /// <summary>
        /// valor total que tiene guardado el socio en el momento de realizar el prestamo.
        /// </summary>
        public decimal ValorCuotasNatillaActual { get; set; }

        /// <summary>
        /// valor el cual se esta prestando.
        /// </summary>
        public decimal ValorPrestado { get; set; }
        /// <summary>
        /// porcentaje que se le aplica al valor o monto que se esta prestando.
        /// </summary>
        public int PorcentajeInteres { get; set; }

        /// <summary>
        /// almacena la informacion de la persona que debe pagar el prestamo
        /// </summary>
        [StringLength(250)]
        public string ResponsablePagoPrestamo { get; set; }

        //relacion un socio puede pertenecer a diferentes natilleras
        public ICollection<CuotasPrestamo> CuotasPrestamo { get; set; }

    }
}
