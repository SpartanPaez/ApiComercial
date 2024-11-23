using System;
using System.Collections.Generic;
using System.Text;

namespace ApiComercial.Models
{
    public class RequestDepartamento
    {
        /// <summary>
        /// Pais asociado
        /// </summary>
        /// <value></value>
        public int PaisId { get; set; }
        /// <summary>
        /// Nombre del departamento
        /// </summary>
        /// <value></value>
        public string? DepartamentoDesc { get; set; }
    }
}