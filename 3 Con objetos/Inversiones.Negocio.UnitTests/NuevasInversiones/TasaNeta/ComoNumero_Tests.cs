using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.TasaNeta_Tests
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

        [TestMethod]
        public void ComoNumero_CasoUnico_FormulaYRedondeo()
        {
            resultadoEsperado = 11.316742081447963800904977370M;

            valorFacial = 320500M;
            valorTransadoNeto = 300000M;
            plazoEnDias = 221;
            diasDelAño = 366M;
            resultadoObtenido = new TasaNeta(valorFacial, valorTransadoNeto, plazoEnDias, diasDelAño).ComoNumero();

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
