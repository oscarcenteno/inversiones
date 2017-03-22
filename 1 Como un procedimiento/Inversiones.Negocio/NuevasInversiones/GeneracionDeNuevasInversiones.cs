using System;

namespace Inversiones.Negocio.NuevasInversiones
{
    public static class GeneracionDeNuevasInversiones
    {
        public static NuevaInversion GenereLaNuevaInversion(decimal valorFacial, decimal valorTransadoNeto, decimal tasaDeImpuesto, DateTime fechaActual, int plazoEnDias, bool tieneTratamientoFiscal)
        {
            NuevaInversion inversion = new NuevaInversion();

            inversion.FechaDeValor = fechaActual;

            inversion.FechaDeVencimiento = fechaActual.AddDays(plazoEnDias);

            decimal diasDelAño;
            int año = fechaActual.Year;
            if (DateTime.IsLeapYear(año))
                diasDelAño = 366;
            else
                diasDelAño = 365;
            decimal plazoEnDiasComoNumeroReal = plazoEnDias;
            decimal tasaNeta = ((valorFacial - valorTransadoNeto) / (valorTransadoNeto * (plazoEnDiasComoNumeroReal / diasDelAño))) * 100;
            decimal tasaBruta = tasaNeta / (1 - tasaDeImpuesto);
            inversion.TasaBruta = tasaBruta;


            decimal valorTransadoBruto;
            if (tieneTratamientoFiscal)
                valorTransadoBruto = valorFacial / (1 + ((tasaBruta / 100) * (plazoEnDias / diasDelAño)));
            else
                valorTransadoBruto = valorTransadoNeto;

            inversion.ValorTransadoBruto = valorTransadoBruto;

            decimal impuestoRedondeado;
            if (tieneTratamientoFiscal)
            {
                decimal impuestoSinRedondear = valorTransadoNeto - valorTransadoBruto;
                impuestoRedondeado = decimal.Round(impuestoSinRedondear, 4);
            }
            else
                impuestoRedondeado = 0;
            inversion.ImpuestoPagado = impuestoRedondeado;

            decimal rendimientoSinRedondear = valorFacial - valorTransadoBruto;
            decimal rendimientoRedondeado = decimal.Round(rendimientoSinRedondear, 4);
            inversion.RendimientoPorDescuento = rendimientoRedondeado;

            return inversion;
        }
    }
}
