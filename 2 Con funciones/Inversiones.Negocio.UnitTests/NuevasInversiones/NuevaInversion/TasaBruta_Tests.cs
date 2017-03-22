using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.NuevaInversion_Tests
{
    [TestClass]
    public class TasaBruta_Tests : Escenarios
    {
        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion inversion;

        [TestMethod]
        public void TasaBruta_ElAñoEsBisiesto_366()
        {
            resultadoEsperado = 12.300806610269525870548888446M;

            inversion = GenereUnaInversionEnAñoBisiestoTieneTratamientoFiscal();
            resultadoObtenido = inversion.TasaBruta;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void TasaBruta_ElAñoNoEsBisiesto_365()
        {
            resultadoEsperado = 12.267197849039281264345202967M;

            inversion = GenereUnaInversionEnAñoNoEsBisiestoTieneTratamientoFiscal();
            resultadoObtenido = inversion.TasaBruta;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
