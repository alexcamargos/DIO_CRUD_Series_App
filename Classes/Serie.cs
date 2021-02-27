using System;

using DIO_CRUD_Series_App.Enum;


namespace DIO_CRUD_Series_App.Classes
{
    public class Serie : Entidade
    {
        // Atributos
        public Serie(Genero genero, string titulo, string descricao, int anoLancamento, bool excluido) 
        {
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.anoLancamento = anoLancamento;
            this.excluido = excluido;
               
        }
        private Genero genero { get; set; }
        private string titulo { get; set; }
        private string descricao { get; set; }
        private int anoLancamento { get; set; }
        private bool excluido { get; set; }

        // Métodos
        public Serie (int id, Genero genero, string titulo, string descricao, int anoLancamento)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.anoLancamento = anoLancamento;
            this.excluido = false;
        }

        public override string ToString()
        {
            var retorno = $"Titulo: {this.titulo + Environment.NewLine}Gênero: {this.genero + Environment.NewLine}Descrição: {this.descricao + Environment.NewLine}Ano de Início: {this.anoLancamento + Environment.NewLine}Excluído: {this.excluido + Environment.NewLine}";

            return retorno;
        }

        public string Titulo()
        {
            return this.titulo;
        }

        public int Id()
        {
            return this.id;
        }

        public bool Excluido()
        {
            return this.excluido;
        }

        public void Excluir()
        {
            this.excluido = true;
        }
    }
}