using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAlfaBravo.Dominio
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }

        public Usuario(string nome, int idade, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
            Email = email;
        }

    }
}
