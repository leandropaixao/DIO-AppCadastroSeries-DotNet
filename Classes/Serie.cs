using System;

namespace DIO_AppCadastroSeries_DotNet.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero _genero;
        private string _titulo;
        private string _descricao;
        private int _ano;
        private bool _excluido;
        private bool _assistido;


        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            _genero = genero;
            _titulo = titulo;
            _descricao = descricao;
            _ano = ano;
            _excluido = false;
            _assistido = false;
        }

        public Serie(Genero genero, string titulo, string descricao, int ano)
        {
            _genero = genero;
            _titulo = titulo;
            _descricao = descricao;
            _ano = ano;
        }

        public override string ToString()
        {
            string retorno = $"#{Id} - {_titulo}" + Environment.NewLine;
            retorno += $"Descrição: {_descricao}" + Environment.NewLine;
            retorno += $"Ano: {_ano}" + Environment.NewLine;
            retorno += $"Asssistido: {(_assistido ? "Sim" : "Não")}";

            return retorno;
        }

        public string retornaTitulo()
        {
            return $"#{Id} - {this._titulo}";
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void excluir()
        {
            this._excluido = true;
        }

        public bool excluido()
        {
            return _excluido;
        }

        public void marcarLida()
        {
            this._assistido = true;
        }

        public bool visualizada()
        {
            return this._assistido;
        }
    }
}