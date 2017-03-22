namespace Inversiones.Negocio.NuevasInversiones
{
    public class ImpuestoRedondeadoConTratamientoFiscal
    {
        decimal impuestoSinRedondear;

        public ImpuestoRedondeadoConTratamientoFiscal(decimal valorTransadoNeto, decimal valorTransadoBruto)
        {
            impuestoSinRedondear = valorTransadoNeto - valorTransadoBruto;
        }

        public decimal ComoNumero()
        {
            return decimal.Round(impuestoSinRedondear, 4);
        }
    }
}