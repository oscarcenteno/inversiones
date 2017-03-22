using System;

namespace Inversiones.Negocio.NuevasInversiones
{
    public class NuevaInversion
    {
        public decimal TasaBruta { get; set; }
        public decimal ValorTransadoBruto { get; set; }
        public decimal ImpuestoPagado { get; set; }
        public decimal RendimientoPorDescuento { get; set; }
        public DateTime FechaDeValor { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
    }
}