using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.NuevaInversion_Tests
{
    [TestClass]
    public class RendimientoPorDescuento_Tests : Escenarios
    {
        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion inversion;

        [TestMethod]
        public void RendimientoPorDescuento_CasoUnico_LaFormula()
        {
            resultadoEsperado = 22159.3592M;

            inversion = GenereUnaInversionEnAñoBisiestoTieneTratamientoFiscal();
            resultadoObtenido = inversion.RendimientoPorDescuento;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}