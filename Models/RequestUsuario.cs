using System;
using System.Collections.Generic;
using System.Text;

namespace ApiComercial.Models
{
    public class RequestUsuario
    {
        /// <summary>
        /// Codigo que asocia a un funcionario(que es cliente ya)
        /// </summary>
        /// <value></value>
        public int ClienteId { get; set; }
        /// <summary>
        /// Indica si el usuario está activo o no
        /// </summary>
        /// <value></value>
        public int UsuarioEstado { get; set; }
        /// <summary>
        /// Nic o user del usuario
        /// </summary>
        /// <value></value>
        public string? UsuarioNic { get; set; }
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        /// <value></value>
        public string? UsuarioPass { get; set; }
        /// <summary>
        /// Fecha de inserción del usuario
        /// </summary>
        /// <value></value>
        public DateTime UsuarioFecha { get; set; }
    }
}