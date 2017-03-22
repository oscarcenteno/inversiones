using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.RendimientoRedondeado_Tests
{
    [TestClass]
    public class ComoNumero_Tests
    {
        private decimal valorFacial;
        private decimal valorTransadoBruto;
        private decimal resultadoEsperado;
        private decimal resultadoObtenido;

        [TestMethod]
        public void ComoNumero_CasoUnico_FormulaYRedondeo()
        {
            resultadoEsperado = 20500M;

            valorFacial = 320500M;
            valorTransadoBruto = 300000M;
            resultadoObtenido = new RendimientoRedondeado(valorFacial, valorTransadoBruto).ComoNumero();

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
