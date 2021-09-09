using System;
using CatalogoJogos.Domain.DomainObjects;
using CatalogoJogos.Domain.MetodosExtensao;

namespace CatalogoJogos.Domain.Models
{
    public class Jogo : Entity
    {
        public string Nome { get; private set; }
        public string Produtora { get; private set; }
        public float Preco { get; private set; }

        private Jogo() {}
        public Jogo(string nome, string produtora, float preco)
        {
            nome.ValidarString();
            produtora.ValidarString();

            Nome = nome;
            Produtora = produtora;
            Preco = preco;
        }
    }
}