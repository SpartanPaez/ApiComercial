using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ApiComercial.Models
{
    public class RequestDatoCliente 
    {  
        
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
        /// Nacionalidad del cliente
        /// </summary>
        /// <value></value>
        public int? ClientePais { get; set; }
        /// <summary>
        /// Indica la ciudad del cliente
        /// </summary>
        /// <value></value>
        public int? ClienteCiudad { get; set; }
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
    public class ClientesValidator: AbstractValidator<RequestDatoCliente>
    {
        public ClientesValidator()
        {
            RuleFor(x=> x.ClienteCedula).MinimumLength(6)
            .WithMessage("La cedula del cliente no cumple con la longitud requerida(6).");
            RuleFor(x=> x.ClienteCedula).MaximumLength(20)
            .WithMessage("La cedula del cliente excede el limite de longitud requerida(20).");

            RuleFor(x=> x.ClienteNombre).MinimumLength(5)
            .WithMessage("El nombre del cliente no cumple con la longitud requerida(5).");
            RuleFor(x=> x.ClienteNombre).MaximumLength(70)
            .WithMessage("El nombre del cliente excede el limite de longitud requeridoa(70).");

            RuleFor(x=> x.ClienteDireccion).MinimumLength(5)
            .WithMessage("La dirección del cliente no cumple con la longitud requerida(5).");
            RuleFor(x=> x.ClienteDireccion).MaximumLength(70)
            .WithMessage("La dirección del cliente excede el limite de longitud requeridoa(70).");

            RuleFor(x=> x.ClienteBarrio).MinimumLength(3)
            .WithMessage("El barrio del cliente no cumple con la longitud requerida(3).");
            RuleFor(x=> x.ClienteBarrio).MaximumLength(70)
            .WithMessage("El barrio del cliente excede el limite de longitud requeridoa(70).");

            RuleFor(x=> x.ClienteCelular).MinimumLength(10)
            .WithMessage("El numero de celular del cliente no cumple con la longitud requerida(10).");
            RuleFor(x=> x.ClienteCelular).MaximumLength(13)
            .WithMessage("El numero de celular del cliente excede el limite de longitud requerida(13).");

            RuleFor(x=> x.ClienteCorreo).MinimumLength(10)
            .WithMessage("El correo del cliente no cumple con la longitud requerida(10).");
            RuleFor(x=> x.ClienteCorreo).MaximumLength(70)
            .WithMessage("El correo del cliente excede el limite de longitud requeridoa(70).");

        }
    }
}