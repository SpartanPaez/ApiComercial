using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ApiComercial.Models
{
    public class ResponseProducto
    {
        /// <summary>
        /// Codigo identificador del producto
        /// </summary>
        /// <value></value>
        public int ProductoId { get; set; }
        /// <summary>
        /// Numero de lote del producto
        /// </summary>
        /// <value></value>
        public string? ProductoLote { get; set; }
        /// <summary>
        /// Codigo de barra del producto
        /// </summary>
        /// <value></value>
        public string? ProductoCodigoBarra { get; set; }
        /// <summary>
        /// Nombre del producto
        /// </summary>
        /// <value></value>
        public string? ProductoNombre { get; set; }
        /// <summary>
        /// Descripcion del producto
        /// </summary>
        /// <value></value>
        public string? ProductoDescripcion { get; set; }
         /// <summary>
        /// Codigo de la categoria del producto
        /// </summary>
        /// <value></value>
        public int IdCategoria { get; set; }
        /// <summary>
        /// precio de costo del producto
        /// </summary>
        /// <value></value>
        public int ProductoCosto { get; set; }
        /// <summary>
        /// Preceio de venta del producto
        /// </summary>
        /// <value></value>
        public int ProductoPrecio { get; set; }
        /// <summary>
        /// Cantidad de existencias
        /// </summary>
        /// <value></value>
        public int ProductoExistencia { get; set; }
        /// <summary>
        /// Id del deposito donde se ubica
        /// </summary>
        /// <value></value>
        public int DepositoId { get; set; }
        /// <summary>
        /// Fecha de vencimiento del producto
        /// </summary>
        /// <value></value>
        public DateTime ProductoFechaVencimiento { get; set; }
        /// <summary>
        /// Fecha de alta del producto
        /// </summary>
        /// <value></value>
        public DateTime ProductoFechaAlta { get; set; }
        /// <summary>
        /// Id del usuario que registra
        /// </summary>
        /// <value></value>
        public int UsuarioId { get; set; }
    }
    public class ProductosValidation : AbstractValidator<RequestProducto>
    {
        public ProductosValidation()
        {
            RuleFor(x => x.ProductoNombre).MinimumLength(3)
            .WithMessage("El nombre del producto debe tener al menos 3 carácteres.");
            RuleFor(x => x.ProductoNombre).MaximumLength(100)
            .WithMessage("El nombre del producto soporta como maxímo 100 carácteres.");
        }
    }
}