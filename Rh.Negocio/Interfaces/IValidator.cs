namespace Rh.Negocio.Interfaces
{
    public interface IValidator<T> where T : class
    {

        void ValidaAdicionar(T domain);
        void ValidaApagar(T domain);
        void ValidaEditar(T domain);
    }
}
