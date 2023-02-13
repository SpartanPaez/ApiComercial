using FluentValidation;

namespace ApiComercial.Entities
{
    public class RequestCiudad
    {
        /// <summary>
        /// Codigo del de departamento asociado
        /// </summary>
        /// <value></value>
        public int DepartamentoId { get; set; }
        /// <summary>
        /// Nombde de la ciudad
        /// </summary>
        /// <value></value>
        public string? CiudadDesc { get; set; }
    }
    public class ValidationActualizaconCiudad : AbstractValidator<RequestCiudad>
    {
        public ValidationActualizaconCiudad()
        {
            RuleFor(p => p.CiudadDesc).MaximumLength(70)
            .WithMessage("La longitud máxima para la descripción de la ciudad es de 70 carácteres.");
            RuleFor(p => p.CiudadDesc).MinimumLength(3)
            .WithMessage("La longitud mínima para la descripción de la ciudad es de 3 carácteres.");
        }
    }
}