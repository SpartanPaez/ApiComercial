using System;
using System.Collections.Generic;
using System.Text;

namespace ApiComercial.Models
{
    public class RequestPais
    {
       /// <summary>
       /// Descripcion del pais
       /// </summary>
        public string? PaisDescripcion { get; set; }
        /// <summary>
        /// Nacionalidad del páis
        /// </summary>
        /// <value></value>
        public string? PaisNacionalidad { get; set; }
    }
}