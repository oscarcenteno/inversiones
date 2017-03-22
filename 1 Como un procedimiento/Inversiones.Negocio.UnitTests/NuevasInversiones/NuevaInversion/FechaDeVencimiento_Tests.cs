using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.NuevaInversion_Tests
{
    [TestClass]
    public class FechaDeVencimiento_Tests: Escenarios
    {
        private DateTime resultadoEsperado;
        private DateTime resultadoObtenido;
        private NuevaInversion inversion;

        [TestMethod]
        public void FechaDeVencimiento_RecibeUnaFechaActualYPlazo_Calculo()
        {
            resultadoEsperado = new DateTime(2016, 10, 10);

            inversion = GenereUnaInversionEnAñoBisiestoTieneTratamientoFiscal();
            resultadoObtenido = inversion.FechaDeVencimiento;

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
