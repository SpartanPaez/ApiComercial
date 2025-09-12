namespace ApiComercial.Entities;
public class Usuario
{

    /// <summary>
    /// Codigo identificador del usuario
    /// </summary>
    /// <value></value>
    public int UsuarioId { get; set; }
    /// <summary>
    /// Indica si el usuario está activo o no
    /// </summary>
    /// <value></value>
    public string? UsuarioEstado { get; set; }
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