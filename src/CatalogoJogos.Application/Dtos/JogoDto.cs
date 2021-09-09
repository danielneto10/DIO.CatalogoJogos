using System;

namespace CatalogoJogos.Application.Dtos
{
    public class JogoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public float Preco { get; set; }
    }
}