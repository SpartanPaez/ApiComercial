namespace ApiComercial.Entities.Recepcion
{
    public class DetalleRecepcion
    {
        public int DetalleRecepcionId { get; set; }
        public int RecepcionId { get; set; }
        public string? IdItem { get; set; }
        public string? Estado { get; set; }
        public string? Observacion { get; set; }
    }
}