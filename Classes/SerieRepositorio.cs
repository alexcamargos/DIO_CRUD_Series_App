using System.Collections.Generic;

using DIO_CRUD_Series_App.Interfaces;


namespace DIO_CRUD_Series_App.Classes
{
    public class SerieRepositorio : InterfaceRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();

        public void InserirSerie(Serie serieObject)
        {
            listaSeries.Add(serieObject);
        }

        public Serie RetornarSeriePorId(int id)
        {
            return listaSeries[id];
        }

        public List<Serie> ListarSerie()
        {
            return listaSeries;
        }

        public void AtualizarSerie(int id, Serie serieObject)
        {
            listaSeries[id] = serieObject;
        }

        public void ExcluirSerie(int id)
        {
            listaSeries[id].Excluir();
        }

        public int RetornarProximoId()
        {
            return listaSeries.Count;
        }
    }
}