using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoJogos.Domain.Models;
using CatalogoJogos.Infrastructure.Context;
using CatalogoJogos.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoJogos.Infrastructure.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly CatalogoJogosContext context;
        public JogoRepository(CatalogoJogosContext context)
        {
            this.context = context;
        }

        public async Task<List<Jogo>> ObterAsync(int pagina, int quantidade)
        {
            IQueryable<Jogo> query = context.Jogos.Skip((pagina - 1) * quantidade).Take(quantidade);
            query.OrderBy(jogo => jogo.Produtora);

            return await query.ToListAsync();
        }
        public async Task<Jogo> ObterAsync(Guid id)
        {
            IQueryable<Jogo> query = context.Jogos.Where(jogo => jogo.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Jogo> ObterAsync(string nome, string produtora)
        {
            IQueryable<Jogo> query = context.Jogos.Where(jogo => jogo.Nome == nome.ToLower() && jogo.Produtora == produtora.ToLower());

            return await query.FirstOrDefaultAsync();
        }
    }
}