using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDato.Models
{
    /// <summary>
    /// entidad o clase que se encarga de almacenar los diferentes tipos de documento.
    /// </summary>
    public class TiposDocumento
    {
        [Key]
        public int TipoDocumentoId { get; set; }
       
        [Required(ErrorMessage ="La descripción del tipo documento es requerida, por favor verifique.")]
        [StringLength(200)]
        public String Descripcion { get; set; }

        //relacionar los datos con la tabla de socios, uno a uno
        //public Socio Socio { get; set; }
    }
}
