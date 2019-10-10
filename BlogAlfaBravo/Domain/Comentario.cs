using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAlfaBravo.Dominio
{
    public class Comentario
    {
        public Usuario Autor { get; set; }
        public string Descricao { get; set; }

        public Comentario(Usuario autor, string descricao)
        {
            Autor = autor;
            Descricao = descricao;
        }
    }
}
