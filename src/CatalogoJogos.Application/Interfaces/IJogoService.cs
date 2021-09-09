using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogos.Application.Dtos;
using CatalogoJogos.Domain.Models;

namespace CatalogoJogos.Application.Interfaces
{
    public interface IJogoService
    {
         Task AddJogo(CreateJogoDto model);
         Task UpdateJogo(Guid id, UpdateJogoDto model);
         Task RemoveJogo(Guid id);
         Task<List<JogoDto>> ObterAsync(int pagina, int quantidade);
         Task<JogoDto> ObterAsync(Guid id);
         Task<JogoDto> ObterAsync(string nome, string produtora);
    }
}