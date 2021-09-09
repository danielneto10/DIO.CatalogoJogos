using CatalogoJogos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoJogos.Infrastructure.Context
{
    public class CatalogoJogosContext : DbContext
    {
        public CatalogoJogosContext(DbContextOptions<CatalogoJogosContext> options) : base(options)
        {
        }

        public DbSet<Jogo> Jogos { get; set; }
    }
}