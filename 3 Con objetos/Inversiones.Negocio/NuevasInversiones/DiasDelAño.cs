using System;

namespace Inversiones.Negocio.NuevasInversiones
{
    public class DiasDelAño
    {
        int año;

        public DiasDelAño(DateTime fechaActual)
        {
            año = fechaActual.Year;
        }

        public decimal ComoNumero()
        {
            if (DateTime.IsLeapYear(año))
                return 366;
            else
                return 365;
        }
    }
}
