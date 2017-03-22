using System;

namespace Inversiones.Negocio.NuevasInversiones
{
    public class NuevaInversion
    {
        private decimal diasDelAño;
        private decimal tasaBruta;
        private decimal valorTransadoBruto;
        private decimal impuestoRedondeado;
        private decimal rendimientoRedondeado;

        public NuevaInversion(decimal valorFacial, decimal valorTransadoNeto, decimal tasaDeImpuesto, DateTime fechaActual, int plazoEnDias, bool tieneTratamientoFiscal)
        {
            FechaDeValor = fechaActual;

            FechaDeVencimiento = CalculeLaFechaDeVencimiento(fechaActual, plazoEnDias);

            diasDelAño = GenereLosDiasDelAño(fechaActual);

            tasaBruta = GenereLaTasaBruta(valorFacial, valorTransadoNeto, tasaDeImpuesto, plazoEnDias, diasDelAño);
            TasaBruta = tasaBruta;

            valorTransadoBruto = DetermineElValorTransadoBruto(valorFacial, valorTransadoNeto, plazoEnDias, tieneTratamientoFiscal, diasDelAño, tasaBruta);
            ValorTransadoBruto = valorTransadoBruto;

            impuestoRedondeado = GenereElImpuestoRedondeado(valorTransadoNeto, tieneTratamientoFiscal, valorTransadoBruto);
            ImpuestoPagado = impuestoRedondeado;

            rendimientoRedondeado = GenereElRendimientoRedondeado(valorFacial, valorTransadoBruto);
            RendimientoPorDescuento = rendimientoRedondeado;
        }

        public decimal TasaBruta { get; private set; }
        public decimal ValorTransadoBruto { get; private set; }
        public decimal ImpuestoPagado { get; private set; }
        public decimal RendimientoPorDescuento { get; private set; }
        public DateTime FechaDeValor { get; private set; }
        public DateTime FechaDeVencimiento { get; private set; }

        private static DateTime CalculeLaFechaDeVencimiento(DateTime fechaActual, int plazoEnDias)
        {
            return fechaActual.AddDays(plazoEnDias);
        }

        private static decimal GenereLosDiasDelAño(DateTime fechaActual)
        {
            return new DiasDelAño(fechaActual).ComoNumero();
        }

        private static decimal GenereLaTasaBruta(decimal valorFacial, decimal valorTransadoNeto, decimal tasaDeImpuesto, int plazoEnDias, decimal diasDelAño)
        {
            return new TasaBruta(valorFacial, valorTransadoNeto, tasaDeImpuesto, plazoEnDias, diasDelAño).ComoNumero();
        }

        private static decimal DetermineElValorTransadoBruto(decimal valorFacial, decimal valorTransadoNeto, int plazoEnDias, bool tieneTratamientoFiscal, decimal diasDelAño, decimal tasaBruta)
        {
            if (tieneTratamientoFiscal)
                return valorFacial / (1 + ((tasaBruta / 100) * (plazoEnDias / diasDelAño)));
            else
                return valorTransadoNeto;
        }

        private static decimal GenereElImpuestoRedondeado(decimal valorTransadoNeto, bool tieneTratamientoFiscal, decimal valorTransadoBruto)
        {
            if (tieneTratamientoFiscal)
                return GenereElImpuestoRedondeadoConTratamientoFiscal(valorTransadoNeto, valorTransadoBruto);
            else
                return 0;
        }

        private static decimal GenereElImpuestoRedondeadoConTratamientoFiscal(decimal valorTransadoNeto, decimal valorTransadoBruto)
        {
            return new ImpuestoRedondeadoConTratamientoFiscal(valorTransadoNeto, valorTransadoBruto).ComoNumero();
        }

        private static decimal GenereElRendimientoRedondeado(decimal valorFacial, decimal valorTransadoBruto)
        {
            return new RendimientoRedondeado(valorFacial, valorTransadoBruto).ComoNumero();
        }
    }
}