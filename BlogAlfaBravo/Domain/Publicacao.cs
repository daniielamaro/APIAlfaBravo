using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAlfaBravo.Dominio
{
    public class Publicacao
    {
        public Guid Id { get; set; }
        public Usuario Autor { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<Comentario> Comentarios { get; set; }

        public Publicacao(Usuario autor, string titulo, string conteudo)
        {
            Id = Guid.NewGuid();
            Autor = autor;
            Titulo = titulo;
            Conteudo = conteudo;
            DataCriacao = DateTime.Now;
            Comentarios = new List<Comentario>();
        }

        public void Comentar(Usuario autor, string descricao)
        {
            Comentario comentario = new Comentario(autor, descricao);
            Comentarios.Add(comentario);
        }

    }
}
