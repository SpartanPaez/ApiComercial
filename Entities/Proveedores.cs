using System;
using System.Collections.Generic;
namespace ApiComercial.Entities;

public class Proveedores
{
    /// <summary>
    /// Codigo identificador del proveedor
    /// </summary>
    /// <value></value>
    public int ProveedorId { get; set; }
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
    /// Telefono del proveedor
    /// </summary>
    /// <value></value>
    public string? ProveedorTelefono { get; set; }
    public string? ProveedorEmail { get; set; }
    public string? ProveedorContacto { get; set; }
    public string? ProveedorRuc { get; set; }
    public string? ProveedorObservaciones { get; set; }
    public DateTime ProveedorFechaAlta { get; set; }
    public DateTime ProveedorFechaModificacion { get; set; }
    public int ProveedorEstado { get; set; }
    public int ProveedorUsuarioAlta { get; set; }
    public int ProveedorUsuarioModificacion { get; set; }
    public int ProveedorUsuarioBaja { get; set; }
    public DateTime ProveedorFechaBaja { get; set; }
    
    }