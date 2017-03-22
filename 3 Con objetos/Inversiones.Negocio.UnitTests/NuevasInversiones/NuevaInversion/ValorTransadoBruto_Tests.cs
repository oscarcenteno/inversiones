using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.NuevaInversion_Tests
{
    [TestClass]
    public class ValorTransadoBruto_Tests : Escenarios
    {
        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private NuevaInversion inversion;

        [TestMethod]
        public void ValorTransadoBruto_TieneTratamientoFiscalYElAñoEsBisiesto_UnaFormula()
        {
            resultadoEsperado = 298340.64080944350758853288365M;

            inversion = GenereUnaInversionEnAñoBisiestoTieneTratamientoFiscal();
            resultadoObtenido = inversion.ValorTransadoBruto;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ValorTransadoBruto_TieneTratamientoFiscalYElAñoNoEsBisiesto_UnaFormula()
        {
            resultadoEsperado = 298340.64080944350758853288362M;

            inversion = GenereUnaInversionEnAñoNoEsBisiestoTieneTratamientoFiscal();
            resultadoObtenido = inversion.ValorTransadoBruto;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ValorTransadoBruto_NoTieneTratamientoFiscalYElAñoEsBisiesto_UnaFormula()
        {
            resultadoEsperado = 300000.0000000000M;

            inversion = GenereUnaInversionEnAñoEsBisiestoNoTieneTratamientoFiscal();
            resultadoObtenido = inversion.ValorTransadoBruto;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
