using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.NuevaInversion_Tests
{
    [TestClass]
    public class ImpuestoPagado_Tests : Escenarios
    {
        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion inversion;

        [TestMethod]
        public void ImpuestoPagado_TieneTratamientoFiscal_Formula()
        {
            resultadoEsperado = 1659.3592M;

            inversion = GenereUnaInversionEnAñoBisiestoTieneTratamientoFiscal();
            resultadoObtenido = inversion.ImpuestoPagado;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ImpuestoPagado_NoTieneTratamientoFiscal_Formula()
        {
            resultadoEsperado = 0;

            inversion = GenereUnaInversionEnAñoEsBisiestoNoTieneTratamientoFiscal();
            resultadoObtenido = inversion.ImpuestoPagado;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
