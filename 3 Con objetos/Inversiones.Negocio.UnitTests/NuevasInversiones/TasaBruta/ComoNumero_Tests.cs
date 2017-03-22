using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.TasaBruta_Tests
{
    [TestClass]
    public class ComoNumero_Tests
    {
        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private decimal valorFacial;
        private decimal valorTransadoNeto;
        private int plazoEnDias;
        private decimal diasDelAño;
        private decimal tasaDeImpuesto;

        [TestMethod]
        public void ComoNumero_CasoUnico_FormulaYRedondeo()
        {
            resultadoEsperado = 12.300806610269525870548888446M;

            valorFacial = 320500M;
            valorTransadoNeto = 300000M;
            plazoEnDias = 221;
            diasDelAño = 366M;
            tasaDeImpuesto = 0.08M;
            resultadoObtenido = new TasaBruta(valorFacial, valorTransadoNeto, tasaDeImpuesto, plazoEnDias, diasDelAño).ComoNumero();

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
