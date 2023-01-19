using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiComercial.Models;

namespace ApiComercial.Models
{
    public interface IclientesServices
    {
        Task<DatoCliente> GetDatoCliente();
    }
}