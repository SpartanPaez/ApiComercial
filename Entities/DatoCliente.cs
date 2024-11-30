using ApiComercial.Entities;
namespace ApiComercial.Entities;

public class Cliente
{
        /// <summary>
        /// Codigo 
        /// </summary>
        /// <value></value>
        public int ClienteId { get; set; }
        /// <summary>
        /// Cedula del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteCedula { get; set; }
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteNombre { get; set; }
        /// <summary>
        /// Dirección del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteDireccion { get; set; }
        /// <summary>
        /// Departamento del cliente
        /// </summary>
        public string? ClienteDepartamento { get; set; }
        /// <summary>
        /// Nacionalidad del cliente
        /// </summary>
        /// <value></value>
        public string? ClientePais { get; set; }
        /// <summary>
        /// Indica la ciudad del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteCiudad { get; set; }
        /// <summary>
        /// Indica el barrio del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteBarrio { get; set; }
        /// <summary>
        /// indica el numero de telefono celular del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteCelular { get; set; }
        /// <summary>
        /// Correo electronico del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteCorreo { get; set; }
        /// <summary>
        /// Estado civil del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteEstadoCivil { get; set; }
        /// <summary>
        /// Estado del cleinte(Activo o no)
        /// </summary>
        /// <value></value>
        public string? ClienteEstado { get; set; }
}