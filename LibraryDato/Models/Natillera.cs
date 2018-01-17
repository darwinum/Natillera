using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDato.Models
{
    public class Natillera
    {
        [Key]
        public int NatilleraId { get; set; }

        /// <summary>
        /// descripcion o nombre de la natillera.
        /// </summary>
        [StringLength(250)]
        public string DescripcionNatillera { get; set; }

        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// indica cuando se debe iniciar con el pago de la cuota
        /// </summary>
        public DateTime FechaInicioPagoCuota { get; set; }

        /// <summary>
        /// tipo de pago si es mensual o quincenal o lo que se quiera parametrizar
        /// </summary>
        [StringLength(250)]
        public string TipoPago { get; set; }

        /// <summary>
        /// es el valor de la cuota que debe dar cada socio.
        /// </summary>
        public Decimal ValorCuota { get; set; }

        /// <summary>
        /// valor que se cobra si hay demora en el pago
        /// </summary>
        public Decimal ValorMora { get; set; }

        /// <summary>
        /// dias que tiene el socio antes de aplicar el calculo del valor de la mora.
        /// </summary>
        public Decimal DiasGraciaMora { get; set; }

        /// <summary>
        /// si es falso el valor mora sera por cada dia, si es verdadero sin importar los dias que se pase del pago
        /// el valor sera el mismo.
        /// </summary>
        public bool ValorMoraDiaFijo { get; set; }

        /// <summary>
        /// no puede ser mayor que 12 cuotas, se calcula partiendo de el mes que los
        /// socios debe empezar con el pago de las cuotas.
        /// </summary>
        public int NumeroCuotas { get; set; }

        //RELACION
        //una natillera puede tener muchas cuotas del socio
        public  ICollection <CuotasSocio> CuotasSocio { get; set; }

        //relacion un socio puede pertenecer a diferentes natilleras
        public ICollection<NatilleraSocio> NatilleraSocio { get; set; }


    }
}
