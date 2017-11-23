namespace Viajante.Dominio.IRepositorio
{
    public interface ITransacao
    {
        void Flush();
        void Begin();
        void Commit();
        void Rollback();
    }
}
