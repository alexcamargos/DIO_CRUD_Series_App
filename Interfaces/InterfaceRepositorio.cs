using System.Collections.Generic;


namespace DIO_CRUD_Series_App.Interfaces
{
    public interface InterfaceRepositorio<T>
    {
        void InserirSerie(T entidade);
        T RetornarSeriePorId(int id);
        List<T> ListarSerie();
        void ExcluirSerie(int id);
        void AtualizarSerie(int id, T entidade);
        int RetornarProximoId();
    }
}