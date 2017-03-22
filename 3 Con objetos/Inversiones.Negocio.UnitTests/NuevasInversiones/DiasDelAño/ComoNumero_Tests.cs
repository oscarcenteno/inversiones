using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inversiones.Negocio.NuevasInversiones;

namespace Inversiones.Negocio.UnitTests.NuevasInversiones.DiasDelAño_Tests
{
    [TestClass]
    public class ComoNumero_Tests
    {
        private decimal resultadoEsperado;
        private decimal resultadoObtenido;
        private DateTime fechaActual;

        [TestMethod]
        public void ComoNumero_FechaActualEsAñoBisiesto_366()
        {
            resultadoEsperado = 366;

            fechaActual = new DateTime(2016, 3, 3);
            resultadoObtenido = new DiasDelAño(fechaActual).ComoNumero();

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void ComoNumero_FechaActualEsAñoNoEsBisiesto_365()
        {
            resultadoEsperado = 365;

            fechaActual = new DateTime(2014, 3, 3);
            resultadoObtenido = new DiasDelAño(fechaActual).ComoNumero();

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}