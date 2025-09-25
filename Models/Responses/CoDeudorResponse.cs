namespace ApiComercial.Models.Responses
{
    public class CoDeudorResponse
    {
        public int ClienteId { get; set; }
        public string? CedulaCliente { get; set; }
        public string? NombreCliente { get; set; }
        public DateTime FechaAgregado { get; set; }
    }
}