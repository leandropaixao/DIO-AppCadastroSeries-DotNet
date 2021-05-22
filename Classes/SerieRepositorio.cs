using System.Linq;
using System.Collections.Generic;
using DIO_AppCadastroSeries_DotNet.Interfaces;
using System;

namespace DIO_AppCadastroSeries_DotNet.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            listaSeries[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSeries[id].excluir();
        }

        public void Inserir(Serie entidade)
        {
            listaSeries.Add(entidade);
        }

        public List<Serie> Listar()
        {
            return listaSeries.FindAll( x => x.excluido() == false);
        }
        public List<Serie> ListarSerieVisualizada()
        {
            return listaSeries.FindAll( x => x.excluido() == false && x.visualizada() == true);
        }
        public List<Serie> ListarSerieNaoVisualizada()
        {
            return listaSeries.FindAll( x => x.excluido() == false && x.visualizada() == false);
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornarPorId(int id)
        {
            return listaSeries.Where(x => x.Id == id && x.excluido() == false).FirstOrDefault();
        }

        public bool ValidarSerie(int id)
        {
            var retorno = listaSeries.FindIndex(x => x.Id == id && x.excluido() == false);
            return retorno >= 0 ? true : false;
        }

        public void MarcarLida(int id)
        {
            listaSeries[id].marcarLida();
        }
    }
}