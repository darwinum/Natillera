using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelosEntidades.Models
{
    public class ActividadesRecaudo
    {
        [Key]
        public int ActividadesRecaudoId { get; set; }

        /// <summary>
        /// se selecciona la natillera para cargar los socios que pertenecen a la misma.
        /// </summary>
        public virtual Natillera Natillera { get; set; }

        /// <summary>
        /// socio el cual es responsable de la actividad.
        /// relacion de muchos a uno con la tabla socios.
        /// solo se deben cargar los socios que han solicitado un prestamo por el formulario prestamo.
        /// </summary>
        public virtual Socio Socio { get; set; }

        /// <summary>
        /// nombre de la actividad
        /// </summary>
        public string DescripcionActividad { get; set; }

        /// <summary>
        /// valor de las cuotas de los socios que se invierten en la actividad
        /// </summary>
        public decimal ValorInvertido { get; set; }

        /// <summary>
        /// valor que se recaudo despues de finalizar la actividad
        /// </summary>
        public decimal ValorRecaudado { get; set; }

        /// <summary>
        /// valor que deja de utilidad despues de terminada la actividad
        /// </summary>
        public decimal ValorNetoGanancia { get; set; }

        /// <summary>
        /// fecha en la que inicia la actividad
        /// </summary>
        public DateTime FechaRealizaActividad { get; set; }

        /// <summary>
        /// fecha actual del sistema
        /// </summary>
        public DateTime FechaCreacion { get; set; }

    }
}
