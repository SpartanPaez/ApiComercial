namespace ApiComercial.Entities
{
    public class VentaCoDeudor
    {
        public int VentaCoDeudorId { get; set; }
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaAgregado { get; set; }
    }
}
