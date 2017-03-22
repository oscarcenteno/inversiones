using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.ImpuestoRedondeadoConTratamientoFiscal_Tests
{
    [TestClass]
    public class ComoNumero_Tests
    {
        private decimal valorTransadoNeto;
        private decimal valorTransadoBruto;
        private decimal resultadoEsperado;
        private decimal resultadoObtenido;

        [TestMethod]
        public void ComoNumero_CasoUnico_FormulaYRedondeo()
        {
            resultadoEsperado = 1659.3592M;

            valorTransadoNeto = 300000M;
            valorTransadoBruto = 298340.64080944350758853288362M;
            resultadoObtenido = new ImpuestoRedondeadoConTratamientoFiscal(valorTransadoNeto, valorTransadoBruto).ComoNumero();

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}