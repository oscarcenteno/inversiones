using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.NuevaInversion_Tests
{
    [TestClass]
    public class FechaDeValor_Tests : Escenarios
    {
        private DateTime resultadoEsperado;
        private NuevaInversion inversion;
        private DateTime resultadoObtenido;

        [TestMethod]
        public void FechaDeValor_RecibeUnaFechaActual_MismaFecha()
        {
            resultadoEsperado = new DateTime(2016, 3, 3);

            inversion = GenereUnaInversionEnAñoBisiestoTieneTratamientoFiscal();
            resultadoObtenido = inversion.FechaDeValor;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
