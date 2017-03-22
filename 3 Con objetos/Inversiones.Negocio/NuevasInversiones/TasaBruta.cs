namespace Inversiones.Negocio.NuevasInversiones
{
    public class TasaBruta
    {
        decimal tasaNeta;
        decimal tasaDeImpuesto;

        public TasaBruta(decimal valorFacial, decimal valorTransadoNeto, decimal tasaDeImpuesto, int plazoEnDias, decimal diasDelAño)
        {
            tasaNeta = GenereLaTasaNeta(valorFacial, valorTransadoNeto, plazoEnDias, diasDelAño);
            this.tasaDeImpuesto = tasaDeImpuesto;
        }

        private static decimal GenereLaTasaNeta(decimal valorFacial, decimal valorTransadoNeto, int plazoEnDias, decimal diasDelAño)
        {
            return new TasaNeta(valorFacial, valorTransadoNeto, plazoEnDias, diasDelAño).ComoNumero();
        }

        public decimal ComoNumero()
        {
            return tasaNeta / (1 - tasaDeImpuesto);
        }
    }
}