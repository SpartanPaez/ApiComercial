using FluentValidation;
namespace ApiComercial.Entities
{
    /// <summary>
    /// Clase request de categorias
    /// </summary>
    public class RequestCategoria
    {
        /// <summary>
        /// Descripcion de la categoria
        /// </summary>
        /// <value></value>
        public string? CategoriaDesc { get; set; }
    }
    /// <summary>
    /// Validación del request
    /// </summary>
    public class ValidationCategoria : AbstractValidator<RequestCategoria>
    {
        /// <summary>
        /// Validación  para los campos de categoría
        /// </summary>
        public ValidationCategoria()
        {
            RuleFor(p => p.CategoriaDesc).MaximumLength(30)
            .WithMessage("La longitud máxima para la descripción de la categoría es de 30 carácteres.");
            RuleFor(p => p.CategoriaDesc).MinimumLength(6)
            .WithMessage("La longitud mínima para la descripción de la categoría es de 30 carácteres.");

        }
    }
}