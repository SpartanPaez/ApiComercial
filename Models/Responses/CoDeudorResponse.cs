namespace ApiComercial.Models.Responses
{
    public class CoDeudorResponse
    {
        public int ClienteId { get; set; }
        public string? CedulaCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaAgregado { get; set; }
    }
}