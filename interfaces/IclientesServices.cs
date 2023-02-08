using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiComercial.interfaces;
using ApiComercial.Models;
using ApiComercial.Entities;

namespace ApiComercial.interfaces
{
    public interface IclientesServices
    {
        Task <IEnumerable<Cliente>> GetDatoCliente();
        Task <Cliente> GetClientePorId(int Id);
        Task <Cliente> InsertCliente(Cliente parametros);
    }
}