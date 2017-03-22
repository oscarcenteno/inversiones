namespace Inversiones.Negocio.NuevasInversiones
{
    public class RendimientoRedondeado
    {
        decimal rendimientoSinRedondear;

        public RendimientoRedondeado(decimal valorFacial, decimal valorTransadoBruto)
        {
            rendimientoSinRedondear = valorFacial - valorTransadoBruto;
        }

        public decimal ComoNumero()
        {
            return decimal.Round(rendimientoSinRedondear, 4);
        }
    }
}