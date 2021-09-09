using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogos.Domain.Models;

namespace CatalogoJogos.Infrastructure.Interfaces
{
    public interface IJogoRepository
    {
         Task<List<Jogo>> ObterAsync(int pagina, int quantidade);
         Task<Jogo> ObterAsync(Guid id);
         Task<Jogo> ObterAsync(string nome, string produtora);

    }
}