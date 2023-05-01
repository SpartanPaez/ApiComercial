using System;
using System.Collections.Generic;
namespace ApiComercial.Entities;

public class Proveedor
{
    /// <summary>
    /// Codigo identificador del proveedor
    /// </summary>
    /// <value></value>
    public int ProveedorId { get; set; }
    /// <summary>
    /// Ruc del proveedor
    /// </summary>
    /// <value></value>
    public string? ProveedorRuc { get; set; }
    /// <summary>
    /// Nombre del proveedor 
    /// </summary>
    /// <value></value>
    public string? ProveedorNombre { get; set; }
    /// <summary>
    /// Direccion del proveedor
    /// </summary>
    /// <value></value>
    public string? ProveedorDireccion { get; set; }
    /// <summary>
    /// Pais de origen del proveedor
    /// </summary>
    /// <value></value>
    public int IdPais { get; set; }
    /// <summary>
    /// Ciudad del proveedor
    /// </summary>
    /// <value></value>
    public int IdCiudad { get; set; }
    /// <summary>
    /// Telefono del proveedor
    /// </summary>
    /// <value></value>
    public string? ProveedorTelefono { get; set; }
    /// <summary>
    /// Correo electronico del proveedor
    /// </summary>
    /// <value></value>
    public string? ProveedorCorreo { get; set; }
    /// <summary>
    /// Estado del proveedor
    /// </summary>
    /// <value></value>
    public int ProveedorEstado { get; set; }
    /// <summary>
    /// Fecha de alta del proveedor
    /// </summary>
    /// <value></value>
    public DateTime ProveedorFechaAlta { get; set; }
    /// <summary>
    /// Usuario que dio de alta al proveedor
    /// </summary>
    /// <value></value>
    public string? ProveedorUsuarioAlta { get; set; }

}