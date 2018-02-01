using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelosEntidades.Models
{
    public class Natillera
    {
        [Key]
        public int NatilleraId { get; set; }

        /// <summary>
        /// descripcion o nombre de la natillera.
        /// </summary>
        [StringLength(250)]
        //[Required(ErrorMessage ="El campo descripción es requerido")]
        //[Display(ResourceType = typeof(MensajesEntidades), Name = "Descripción")]      
        [Required(ErrorMessageResourceType = typeof(MensajesEntidades), ErrorMessageResourceName = "NatilleraDescripcion")]
        public string DescripcionNatillera { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]       
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// indica cuando se debe iniciar con el pago de la cuota
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$", ErrorMessageResourceType = typeof(MensajesEntidades), ErrorMessageResourceName = "NatilleraDiasGraciaMoraNumero")]
        public DateTime FechaInicioPagoCuota { get; set; }
       
        /// <summary>
        /// tipo de pago si es mensual o quincenal o lo que se quiera parametrizar
        /// </summary>       
        [DataType(DataType.Currency)]
        public int TipoPago { get; set; }

        /// <summary>
        /// es el valor de la cuota que debe dar cada socio.
        /// </summary>
        [DataType(DataType.Currency)]
        public Decimal ValorCuota { get; set; }

        /// <summary>
        /// valor que se cobra si hay demora en el pago
        /// </summary>
        [DataType(DataType.Currency)]
        public Decimal ValorMora { get; set; }

        /// <summary>
        /// dias que tiene el socio antes de aplicar el calculo del valor de la mora.
        /// </summary>
       
        [RegularExpression("([1-9][0-9]*)", ErrorMessageResourceType = typeof(MensajesEntidades), ErrorMessageResourceName = "NatilleraDiasGraciaMoraNumero")]
        [DataType(DataType.Currency)]
        [Range(1, 30, ErrorMessage = "El valor debe estar entre 1 - 30, por favor verifique")]
        public int DiasGraciaMora { get; set; }

        /// <summary>
        /// si es falso el valor mora sera por cada dia, si es verdadero sin importar los dias que se pase del pago
        /// el valor sera el mismo.
        /// </summary>
        public bool ValorMoraDiaFijo { get; set; }

        /// <summary>
        /// no puede ser mayor que 12 cuotas, se calcula partiendo de el mes que los
        /// socios debe empezar con el pago de las cuotas.
        /// </summary>
        [RegularExpression("([1-9][0-9]*)", ErrorMessageResourceType = typeof(MensajesEntidades), ErrorMessageResourceName = "NatilleraDiasGraciaMoraNumero")]
        [Range(1, 12,ErrorMessage ="El valor debe estar entre 1 - 12, por favor verifique")]
        [Required(ErrorMessageResourceType = typeof(MensajesEntidades), ErrorMessageResourceName = "NatilleraDescripcion")]
        [DataType(DataType.Currency)]
        public int NumeroCuotas { get; set; }

        //RELACION
        //una natillera puede tener muchas cuotas del socio
        public  ICollection <CuotasSocio> CuotasSocio { get; set; }

        //relacion un socio puede pertenecer a diferentes natilleras
        public ICollection<NatilleraSocio> NatilleraSocio { get; set; }


    }
}
