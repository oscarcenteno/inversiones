using Inversiones.Negocio.NuevasInversiones;
using System;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.NuevaInversion_Tests
{
    public class Escenarios
    {
        private DateTime fechaActual;
        private int plazoEnDias;
        private decimal tasaDeImpuesto;
        private bool tieneTratamientoFiscal;
        private decimal valorFacial;
        private decimal valorTransadoNeto;

        public NuevaInversion GenereUnaInversionEnAñoBisiestoTieneTratamientoFiscal()
        {
            fechaActual = new DateTime(2016, 3, 3);
            plazoEnDias = 221;
            valorTransadoNeto = 300000M;
            valorFacial = 320500;
            tasaDeImpuesto = 0.08M;
            tieneTratamientoFiscal = true;

            return new NuevaInversion(valorFacial, valorTransadoNeto, tasaDeImpuesto, fechaActual, plazoEnDias, tieneTratamientoFiscal);
        }

        public NuevaInversion GenereUnaInversionEnAñoNoEsBisiestoTieneTratamientoFiscal()
        {
            fechaActual = new DateTime(2014, 3, 3);
            plazoEnDias = 221;
            valorTransadoNeto = 300000M;
            valorFacial = 320500;
            tasaDeImpuesto = 0.08M;
            tieneTratamientoFiscal = true;

            return new NuevaInversion(valorFacial, valorTransadoNeto, tasaDeImpuesto, fechaActual, plazoEnDias, tieneTratamientoFiscal);
        }

        public NuevaInversion GenereUnaInversionEnAñoEsBisiestoNoTieneTratamientoFiscal()
        {
            fechaActual = new DateTime(2016, 3, 3);
            plazoEnDias = 221;
            valorTransadoNeto = 300000M;
            valorFacial = 320500;
            tasaDeImpuesto = 0.08M;
            tieneTratamientoFiscal = false;

            return new NuevaInversion(valorFacial, valorTransadoNeto, tasaDeImpuesto, fechaActual, plazoEnDias, tieneTratamientoFiscal);
        }


    }
}
