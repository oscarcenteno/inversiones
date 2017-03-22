using System;

namespace Inversiones.Negocio.NuevasInversiones
{
    public static class GeneracionDeNuevasInversiones
    {
        public static NuevaInversion GenereLaNuevaInversion(decimal valorFacial, decimal valorTransadoNeto, decimal tasaDeImpuesto, DateTime fechaActual, int plazoEnDias, bool tieneTratamientoFiscal)
        {
            NuevaInversion inversion = new NuevaInversion();

            inversion.FechaDeValor = fechaActual;

            inversion.FechaDeVencimiento = CalculeLaFechaDeVencimiento(fechaActual, plazoEnDias);

            decimal diasDelAño = GenereLosDiasDelAño(fechaActual);

            decimal tasaBruta = GenereLaTasaBruta(valorFacial, valorTransadoNeto, tasaDeImpuesto, plazoEnDias, diasDelAño);
            inversion.TasaBruta = tasaBruta;

            decimal valorTransadoBruto = DetermineElValorTransadoBruto(valorFacial, valorTransadoNeto, plazoEnDias, tieneTratamientoFiscal, diasDelAño, tasaBruta);
            inversion.ValorTransadoBruto = valorTransadoBruto;

            decimal impuestoRedondeado = GenereElImpuestoRedondeado(valorTransadoNeto, tieneTratamientoFiscal, valorTransadoBruto);
            inversion.ImpuestoPagado = impuestoRedondeado;

            decimal rendimientoRedondeado = GenereElRendimientoRedondeado(valorFacial, valorTransadoBruto);
            inversion.RendimientoPorDescuento = rendimientoRedondeado;

            return inversion;
        }

        private static DateTime CalculeLaFechaDeVencimiento(DateTime fechaActual, int plazoEnDias)
        {
            return fechaActual.AddDays(plazoEnDias);
        }

        private static decimal GenereLosDiasDelAño(DateTime fechaActual)
        {
            int año = ExtraigaElAño(fechaActual);

            return DetermineLosDiasDelAño(año);
        }

        private static int ExtraigaElAño(DateTime fechaActual)
        {
            return fechaActual.Year;
        }

        private static decimal DetermineLosDiasDelAño(int año)
        {
            if (DateTime.IsLeapYear(año))
                return 366;
            else
                return 365;
        }

        private static decimal GenereLaTasaBruta(decimal valorFacial, decimal valorTransadoNeto, decimal tasaDeImpuesto, int plazoEnDias, decimal diasDelAño)
        {
            decimal tasaNeta = GenereLaTasaNeta(valorFacial, valorTransadoNeto, plazoEnDias, diasDelAño);

            return CalculeLaTasaBruta(tasaDeImpuesto, tasaNeta);
        }

        private static decimal GenereLaTasaNeta(decimal valorFacial, decimal valorTransadoNeto, int plazoEnDias, decimal diasDelAño)
        {
            decimal plazoEnDiasComoNumeroReal = plazoEnDias;

            return CalculeLaTasaNeta(valorFacial, valorTransadoNeto, diasDelAño, plazoEnDiasComoNumeroReal);
        }

        private static decimal CalculeLaTasaNeta(decimal valorFacial, decimal valorTransadoNeto, decimal diasDelAño, decimal plazoEnDiasComoNumeroReal)
        {
            return ((valorFacial - valorTransadoNeto) / (valorTransadoNeto * (plazoEnDiasComoNumeroReal / diasDelAño))) * 100;
        }

        private static decimal CalculeLaTasaBruta(decimal tasaDeImpuesto, decimal tasaNeta)
        {
            return tasaNeta / (1 - tasaDeImpuesto);
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
            decimal impuestoSinRedondear = CalculeElImpuestoSinRedondear(valorTransadoNeto, valorTransadoBruto);

            return RedondeeElImpuesto(impuestoSinRedondear);
        }

        private static decimal CalculeElImpuestoSinRedondear(decimal valorTransadoNeto, decimal valorTransadoBruto)
        {
            return valorTransadoNeto - valorTransadoBruto;
        }

        private static decimal RedondeeElImpuesto(decimal impuestoSinRedondear)
        {
            return decimal.Round(impuestoSinRedondear, 4);
        }

        private static decimal GenereElRendimientoRedondeado(decimal valorFacial, decimal valorTransadoBruto)
        {
            decimal rendimientoSinRedondear = CalculeElRendimientoSinRedondear(valorFacial, valorTransadoBruto);

            return RedondeeElRendimiento(rendimientoSinRedondear);
        }

        private static decimal CalculeElRendimientoSinRedondear(decimal valorFacial, decimal valorTransadoBruto)
        {
            return valorFacial - valorTransadoBruto;
        }

        private static decimal RedondeeElRendimiento(decimal rendimientoSinRedondear)
        {
            return decimal.Round(rendimientoSinRedondear, 4);
        }
    }
}
