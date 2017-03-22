namespace Inversiones.Negocio.NuevasInversiones
{
    public class TasaNeta
    {
        decimal plazoEnDiasComoNumeroReal;
        decimal valorFacial;
        decimal valorTransadoNeto;
        decimal diasDelAño;

        public TasaNeta(decimal valorFacial, decimal valorTransadoNeto, int plazoEnDias, decimal diasDelAño)
        {
            plazoEnDiasComoNumeroReal = plazoEnDias;
            this.valorFacial = valorFacial;
            this.valorTransadoNeto = valorTransadoNeto;
            this.diasDelAño = diasDelAño;
        }

        public decimal ComoNumero()
        {
            return ((valorFacial - valorTransadoNeto) / (valorTransadoNeto * (plazoEnDiasComoNumeroReal / diasDelAño))) * 100;
        }
    }
}
